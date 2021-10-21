using BadGangMinton.DAL;
using BadGangMinton.View.Model;
using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var model = new RegistrationViewModel();
            List<GenderType> genderTypes = new List<GenderType>();
            genderTypes.Add(new GenderType() { Id = 1, Name = "Male" });
            genderTypes.Add(new GenderType() { Id = 2, Name = "Female" });

            model.SalutationSelectList = new SelectList(lookupDal.GetAllSalutation(), "Id", "Name");
            model.GenderSelectList = new SelectList(genderTypes, "Id", "Name");

            return View(model);
        }

        public ActionResult Disclaimer()
        {
            return View();
        }


        public ActionResult Privacy()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult ThankYouForJoining(string name, string emailAddress)
        {
            ViewBag.Message = "Thank You For Joining";
            ViewBag.Title = "Welcome to Badminton Crew";
            ViewBag.Name = name;
            ViewBag.Email = emailAddress;
            return View();
        }

        public ActionResult ThankYouForContactingUs(string name, string emailAddress)
        {
            ViewBag.Message = "Thank You For Contacting Us";
            ViewBag.Title = "Welcome to Badminton Crew";
            ViewBag.Name = name;
            ViewBag.Email = emailAddress;
            return View();
        }


        
        public ActionResult ThankYouForVerification(string name, string emailAddress)
        {
            ViewBag.Message = "Thank You For Joining";
            ViewBag.Title = "Welcome to Badminton Crew";
            ViewBag.Name = name;
            ViewBag.Email = emailAddress;
            return View();
        }

        public ActionResult ThankYouForChangingPassword(string name, string emailAddress)
        {
            ViewBag.Message = "Thank You For Joining";
            ViewBag.Title = "Welcome to Badminton Crew";
            ViewBag.Name = name;
            ViewBag.Email = emailAddress;
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }

        public ActionResult Login()
        {
            ViewBag.Title = "Login";
            Login lVM = new Login();
            return View(lVM);
        }

        public ActionResult LogOut()
        {
            sDal.LogMe("TRACKING", "LOGGED OUT FROM SYSTEM", sm.UserSession.Person.Id);
            sm.UserSession = null;
            return RedirectToAction("Login", "Home");
        }

        public ActionResult ForgotPassword()
        {
            return View(new ForgotPassword());
        }

        [HttpPost]
        public ActionResult ResetPassword(ForgotPassword model)
        {
            if (ModelState.IsValid)
            {
                bool canRequest = true;

                var person = sDal.GetPersonByUserName(model.UserName);


                if (person.Id == 0 || !person.IsActive)
                {
                    ViewBag.Message = "Username is invalid";
                    canRequest = false;
                }

                if (canRequest)
                {
                    if (sDal.GetPeronSecurityCodeBySecurityType(person.Id, "FORGOTPASSWORD").Where(x => x.ExpiredOn.HasValue == false).Count() >= 2)
                    {
                        TempData["ERR_Message"] = "Looks like, We had already sent you the password reset instructions.If you haven't received an email from us, please check your spam or junk mail folder.";
                        canRequest = false;
                    }
                }

                if (canRequest)
                {
                    var code = sDal.RaisePersonSecurityRequest(person.Id, "FORGOTPASSWORD");

                    string resetLink = string.Format("http://{0}/verifypassword/{1}", System.Web.HttpContext.Current.Request.Url.Authority, code);

                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("NAME", $"{person.Name}");
                    param.Add("SECURITYCODE", code);
                    param.Add("RESETLINK", resetLink);
                    string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpForgotPassword.html", param);

                    person.PersonEmail = cDal.GetPersonEmailByPersonId(person.Id);

                    var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 3).FirstOrDefault();

                    var q = mxDAL.PushNotification(person, param, mxType.Id, person.PersonEmail.Where(t => t.Type.Id == 1).FirstOrDefault().Value, html);

                    sDal.LogMe("TRACKING", "PASSWORD RESET HAS BEEN RAISED", person.Id);

                    var res = emailService.EmailBySMTP(person.PersonEmail.Where(t => t.Type.Id == 1).FirstOrDefault().Value, ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);

                    if (res.HasError)
                    {
                        sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {res.ErrorMessage}", person.Id);

                        mxDAL.UpdateNotification(q.Id);
                    }

                    sDal.LogMe("TRACKING", "RESET PASSWORD REQUEST HAS BEEN REQUESTED", person.Id);

                }

                TempData["PasswordReset"] = canRequest;

                return RedirectToAction("Login", "Home");
            }
            else
            {
                return RedirectToAction("ForgotPassword", "Home", new ForgotPassword());
            }
        }

        [HttpGet]
        public ActionResult verifypassword(string Code)
        {
            ResetPasswordViewModel rpVM = new ResetPasswordViewModel();

            Person isValid = sDal.ValidateSecurityCode(Code);

            if (isValid == null)
            {
                return RedirectToAction("Login", "Home");
            }
            else
            {
                rpVM.PersonId = isValid.Id;
                rpVM.EmailAddress = cDal.GetPersonEmailByPersonId(isValid.Id).Where(t => t.Type.Id == 1).FirstOrDefault().Value;
                rpVM.FName = isValid.Fname;
                rpVM.LName = isValid.Lname;
                rpVM.SecurityCode = Code;
            }

            return View("ResetPassword", rpVM);
        }

        [HttpPost]
        public ActionResult ApplySecurityCodeForRestPassword(ResetPasswordViewModel model)
        {
            int mid = 0;
            if (ModelState.IsValid)
            {
                mid = sDal.ApplySecurityCode(model.PersonId, model.SecurityCode, model.Password);
            }

            sDal.ExpireSecurityCode(mid,2);

            sDal.LogMe("TRACKING", "PASSWORD HAS BEEN CHANGED", model.PersonId);

            return RedirectToAction("ThankYouForChangingPassword", "Home");
        }




        [HttpPost]
        public ActionResult ValidateUser(string UserName, string Password)
        {
            LoginStatus status = sDal.ValidateUser(UserName, Password);
            if (status.Success)
            {
                sm.UserSession = status.LoggedInPerson;
                sDal.LogMe("TRACKING", "LOGGED IN SYSTEM", sm.UserSession.Person.Id);
                if (sm.UserSession.RoleNameList.Contains("sysadmin"))
                {
                    sDal.ExpireSecurityCode(sm.UserSession.Person.Id, 2);

                    return RedirectToAction("Index", "Admin");
                }
                else
                {
                    if (sm.UserSession.RoleNameList.Contains("player"))
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
            }

            ViewBag.Message = "Invalid Username or password";
            return View("login", new Login());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult JoineMe(RegistrationViewModel pVM)
        {
            if (ModelState.IsValid)
            {
                BGO.Contact.Person p = new BGO.Contact.Person()
                {
                    CreatedOn = DateTime.Now,
                    DOB = pVM.DateOfBirth.Value,
                    Fname = pVM.FirstName,
                    Mname = pVM.MiddleName,
                    Lname = pVM.LastName,
                    IsActive = false,
                    GenderId = Int16.Parse(pVM.Gender),
                    SalutationId = 1,
                    IPaddress = GetUserIp()
                };

                BGO.Contact.PersonEmail pe = new BGO.Contact.PersonEmail()
                {
                    Type = new BGO.Contact.EmailType() { Id = 1, Name = "PERSONAL" },
                    Value = pVM.PrimaryEmail
                };

                BGO.Contact.PersonPhone ph = new BGO.Contact.PersonPhone()
                {
                    Type = new BGO.Contact.PhoneType() { Id = 1, Name = "MOBILE" },
                    Value = pVM.PhoneNumber
                };

                int newPersonId = cDal.SavePerson(p);

                int newPersonEmailId = cDal.SavePersonEmail(newPersonId, pe);

                int newPersonPhoneId = cDal.SavePersonPhone(newPersonId, ph);

                sDal.LogMe("TRACKING", "NEW JOINEE REQUEST HAS BEEN RECEIVED", newPersonId);

                try
                {
                    var code = sDal.RaisePersonSecurityRequest(newPersonId, "JOINING");

                    string verificationLink = string.Format("http://{0}/verify/{1}", System.Web.HttpContext.Current.Request.Url.Authority, code);

                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("NAME", $"{pVM.FirstName} {pVM.LastName}");
                    param.Add("VERIFICATIONLINK", verificationLink);

                    string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpjoining.html", param);

                    var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 1).FirstOrDefault();

                    var q = mxDAL.PushNotification(cDal.GetPersonByPersonId(newPersonId), param, mxType.Id, pVM.PrimaryEmail, html);

                    var res = emailService.EmailBySMTP(pVM.PrimaryEmail, ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);

                    if (res.HasError)
                    {
                        sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {res.ErrorMessage}", newPersonId);

                        mxDAL.UpdateNotification(q.Id);
                    }
                }
                catch (Exception ex)
                {
                    sDal.LogMe("EXCEPTION", ex.InnerException.Message, p.Id);
                }

                return RedirectToAction("ThankYouForJoining", new { Name = pVM.FirstName, EmailAddress = pVM.PrimaryEmail });
            }
            else
            {
                return RedirectToAction("Index");
            }

            
        }

        [HttpGet]
        public ActionResult Verify(string Code)
        {
            var data = sDal.GetPersonSecurityCodeByCode(Code);
            if (data == null)
            {
                return RedirectToAction("Login");
            }

            if (data.ExpiredOn.HasValue)
            {
                return RedirectToAction("Login");
            }


            VerifictionViewModel rVM = new VerifictionViewModel()
            {
                FirstName = data.Person.Fname,
                MiddleName = data.Person.Mname,
                LastName = data.Person.Lname,
                PrimaryEmail = cDal.GetPersonEmailByPersonId(data.Person.Id).Where(x => x.Type.Id == 1).FirstOrDefault().Value,
                PhoneNumber = cDal.GetPersonPhoneByPersonId(data.Person.Id).Where(x => x.Type.Id == 1).FirstOrDefault().Value,
                PersonId = data.Person.Id,
                VerificationCode = Code,
                DateOfBirth = data.Person.DOB,
                SalutuionId = data.Person.SalutationId.ToString(),
                Gender = data.Person.GenderId.ToString()

            };
            return View(rVM);
        }

        public ActionResult GetPersonList()
        {
            AttachPersonViewModel apVM = new AttachPersonViewModel();           
            List<Person> people = new List<Person>(); 
            people= cDal.GetPeople().Where(c=>c.GroupId.HasValue==false).ToList();
            apVM.People = new SelectList(people, "Id", "Name");                    
            return PartialView("_PersonList", apVM);
        }

        public ActionResult GetSupport()
        {
            SupportViewModel model = new SupportViewModel();

            if (sm.UserSession != null)
            {
                model.Name = sm.UserSession.Person.Name;
                model.EmailAddress = sm.UserSession.Person.PersonEmail.FirstOrDefault().Value;
            }
            else
            {
                model.isMemnber = false;
            }

            return PartialView("_SupportPopup", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CompleteRegistration(VerifictionViewModel pVM)
        {
            if (ModelState.IsValid)
            {
                sDal.ApplyPersonSecurityCode(pVM.PersonId, pVM.VerificationCode);              

                sDal.SaveUserLogin(pVM.UserName, Helpers.BGHelper.ComputeHash(pVM.Password), pVM.PersonId);

                cDal.UpdatePerson(pVM.FirstName, pVM.MiddleName, pVM.LastName, pVM.PersonId, Int16.Parse(pVM.Gender), pVM.DateOfBirth.Value, int.Parse(pVM.SalutuionId));

                sDal.LogMe("TRACKING", "REGISTRATION HAS BEEN COMPLTED", pVM.PersonId);

                mDal.CreateMember(pVM.PersonId, DateTime.Now.Date, 2, true);

                sDal.LogMe("TRACKING", "MEMBERSHIP HAS BEEN COMPLTED", pVM.PersonId);

                try
                {
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("NAME", $"{pVM.FirstName} {pVM.LastName}");
                    param.Add("Username", pVM.UserName);
                    param.Add("Password", pVM.Password);
                    string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpCredential.html", param);

                    var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 2).FirstOrDefault();

                    var q = mxDAL.PushNotification(cDal.GetPersonByPersonId(pVM.PersonId), param, mxType.Id, pVM.PrimaryEmail, html);

                    var res = emailService.EmailBySMTP(pVM.PrimaryEmail, ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);

                    if (res.HasError)
                    {
                        sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {res.ErrorMessage}", pVM.PersonId);

                        mxDAL.UpdateNotification(q.Id);
                    }


                }
                catch (Exception ex)
                {
                    sDal.LogMe("EXCEPTION", ex.InnerException.Message, pVM.PersonId);
                }

            }

            ViewBag.Name = pVM.FirstName;

            return RedirectToAction("ThankYouForVerification", new { Name = pVM.FirstName, EmailAddress = pVM.PrimaryEmail });
        }

        public ActionResult RaiseSupportQuery(SupportViewModel model)
        {
            string responseCode = "OK";
            var person = cDal.GetPersonByEmailAddress(model.EmailAddress);

            if (person.Id > 0)
            {
                var personLog = lookupDal.GetPersonLog(person.Id).Where(x => x.Description == "SUPPORT QUERY HAS BEEN RAISED").OrderByDescending(o => o.CreatedOn).GroupBy(g => g.CreatedOn);
                try
                {
                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("NAME", $"{person.Name}");
                    param.Add("MESSAGE", model.Message);
                    param.Add("Emailaddress", model.EmailAddress);

                    string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpSupport.html", param);
                    var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 5).FirstOrDefault();
                    mxDAL.CheckMailoutParameters(param, mxType.Id);

                    var res = emailService.EmailBySMTP(ConfigurationManager.AppSettings["Support_Email"], ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);

                    if (res.HasError)
                    {
                        sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {res.ErrorMessage}", person.Id);
                        responseCode = res.ErrorMessage;
                    }

                }
                catch (Exception ex)
                {
                    responseCode = ex.Message;
                }

                sDal.LogMe("TRACKING", "SUPPORT QUERY HAS BEEN RAISED", person.Id);
            }
            else
            {
                responseCode = "NF";
            }

            return Json(new { Ok = responseCode }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ConatactUs(SupportViewModel model)
        {
            if (ModelState.IsValid)
            {

                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("NAME", $"{model.Name}");
                param.Add("MESSAGE", model.Message);
                param.Add("Emailaddress", model.EmailAddress);

                string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpSupport.html", param);
                var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 5).FirstOrDefault();
                mxDAL.CheckMailoutParameters(param, mxType.Id);
                var res = emailService.EmailBySMTP(ConfigurationManager.AppSettings["Support_Email"], ConfigurationManager.AppSettings["SMTP_FROM"], html, $"{mxType.Subject} : {model.Subject}");
            }

            return RedirectToAction("ThankYouForContactingUs", new { Name = model.Name, EmailAddress = model.EmailAddress });
        }
    }
}