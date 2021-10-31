using BadGangMinton.View.Model;
using BGO.Common;
using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.Controllers
{
    public class AccountController : MemberController
    {

        public ActionResult Index()
        {
            ViewBag.Message = "Your Account";
            ViewBag.Title = "My Account";
            return View();
        }

        public ActionResult MyProfile()
        {
            ViewBag.Message = "My Profile";
            ViewBag.Title = "My Profile";
            PersonViewModel myProfile = new PersonViewModel()
            {
                Id = sm.UserSession.Person.Id,
                FirstName = sm.UserSession.Person.Fname,
                MiddleName = sm.UserSession.Person.Mname,
                LastName = sm.UserSession.Person.Lname,
                DOB = sm.UserSession.Person.DOB.Date,
                DateCreated = sm.UserSession.Person.CreatedOn,
                GenderTypeId = sm.UserSession.Person.GenderId.ToString(),
                SalutationTypeId = sm.UserSession.Person.SalutationId.ToString(),
                GroupId = sm.UserSession.Person.GroupId
            };

            List<BGO.Common.GenderType> genderTypes = new List<BGO.Common.GenderType>();
            List<Salutation> salutationTypes = new List<Salutation>();

            genderTypes.Add(new BGO.Common.GenderType() { Id = 1, Name = "Male" });
            genderTypes.Add(new BGO.Common.GenderType { Id = 2, Name = "Female" });

            salutationTypes = lookupDal.GetAllSalutation();
            myProfile.Gender = new SelectList(genderTypes, "Id", "Name");
            myProfile.Salutations = new SelectList(salutationTypes, "Id", "Name");

            myProfile.PersonAddress = new List<Address>();
            myProfile.PersonContactNumber = new List<Contact>();
            myProfile.PersonEmail = new List<EmailAddress>();

            var addresses = cDal.GetPersonAddressesByPersonId(sm.UserSession.Person.Id);
            var phones = cDal.GetPersonPhoneByPersonId(sm.UserSession.Person.Id);
            var emails = cDal.GetPersonEmailByPersonId(sm.UserSession.Person.Id);

            if (cDal.GetPersonEmailByPersonId(sm.UserSession.Person.Id).Where(x => x.Type.Id == 1).Count() > 0)
                myProfile.PrimaryEmail = cDal.GetPersonEmailByPersonId(sm.UserSession.Person.Id).Where(x => x.Type.Id == 1).FirstOrDefault().Value;

            if (cDal.GetPersonPhoneByPersonId(sm.UserSession.Person.Id).Where(x => x.Type.Id == 1).Count() > 0)
                myProfile.PrimaryContactNumber = cDal.GetPersonPhoneByPersonId(sm.UserSession.Person.Id).FirstOrDefault().Value;


            foreach (var a in addresses)
            {
                myProfile.PersonAddress.Add(new Address { City = a.City, CountryId = a.CountryId, CreatedOn = a.CreatedOn, Id = a.Id, Landmark = a.Landmark, Line1 = a.Line1, Line2 = a.Line2, PostCode = a.Postcode, State = a.State, Type = new BGO.Common.AddressType() { Id = a.AddressType.Id, Name = a.AddressType.Name } });
            }

            foreach (var a in phones)
            {
                myProfile.PersonContactNumber.Add(new Contact() { Id = a.Id, CreatedOn = a.CreatedOn, Type = new ContactNumberType() { Id = a.Type.Id, Name = a.Type.Name }, Value = a.Value });
            }

            foreach (var a in emails)
            {
                myProfile.PersonEmail.Add(new EmailAddress() { Id = a.Id, DateCreated = a.CreatedOn, Type = new BGO.Common.EmailType() { Id = a.Type.Id, Name = a.Type.Name }, Value = a.Value });
            }

            myProfile.PrimaryContactNumber = myProfile.PrimaryContactNumber == null ? "000000000000" : myProfile.PrimaryContactNumber;

            return View(myProfile);
        }

        public ActionResult MyAttendance()
        {
            ViewBag.Message = "My Attendance";
            ViewBag.Title = "My Attendance";

            var attendanceList = txDAL.GetAttendanceByPersonId(sm.UserSession.Person.Id);

            return View(attendanceList);
        }

        public ActionResult MyBalance()
        {
            ViewBag.Message = "My Balance";
            ViewBag.Title = "My Balance";

            var txList = txDAL.GetTransaction(sm.UserSession.Person.Id);

            return View(txList);
        }

        public ActionResult MyBuddyList()
        {
            ViewBag.Message = "My Buddy";
            ViewBag.Title = "My Buddy";

            var buddyList = cDal.GetBuddyListByPersonId(sm.UserSession.Person.Id);

            return View(buddyList);
        }


        public ActionResult MyBuddyProfile(int personId)
        {
            ViewBag.Message = "My Profile";
            ViewBag.Title = "My Profile";

            var p = cDal.GetPersonByPersonId(personId);

            if (p.Group == null)
            {
                throw new Exception("unauthorized buddy profile has been accessed");
            }

            if (p.GroupId != sm.UserSession.Person.Id)
            {
                throw new Exception("unauthorized buddy profile has been accessed");
            }

            PersonViewModel myBuddyProfile = new PersonViewModel()
            {
                Id = p.Id,
                FirstName = p.Fname,
                MiddleName = p.Mname,
                LastName = p.Lname,
                DOB = p.DOB,
                DateCreated = p.CreatedOn,
                GenderTypeId = p.GenderId.ToString(),
                SalutationTypeId = p.SalutationId.ToString(),
                GroupId = p.GroupId
            };

            List<BGO.Common.GenderType> genderTypes = new List<BGO.Common.GenderType>();
            List<Salutation> salutationTypes = new List<Salutation>();

            genderTypes.Add(new BGO.Common.GenderType() { Id = 1, Name = "Male" });
            genderTypes.Add(new BGO.Common.GenderType { Id = 2, Name = "Female" });

            salutationTypes = lookupDal.GetAllSalutation();
            myBuddyProfile.Gender = new SelectList(genderTypes, "Id", "Name");
            myBuddyProfile.Salutations = new SelectList(salutationTypes, "Id", "Name");

            myBuddyProfile.PersonAddress = new List<Address>();
            myBuddyProfile.PersonContactNumber = new List<Contact>();
            myBuddyProfile.PersonEmail = new List<EmailAddress>();

            var addresses = cDal.GetPersonAddressesByPersonId(p.Id);
            var phones = cDal.GetPersonPhoneByPersonId(p.Id);
            var emails = cDal.GetPersonEmailByPersonId(p.Id);


            if (cDal.GetPersonEmailByPersonId(p.Id).Where(x => x.Type.Id == 1).Count() > 0)
                myBuddyProfile.PrimaryEmail = cDal.GetPersonEmailByPersonId(p.Id).Where(x => x.Type.Id == 1).FirstOrDefault().Value;

            if (cDal.GetPersonPhoneByPersonId(p.Id).Where(x => x.Type.Id == 1).Count() > 0)
                myBuddyProfile.PrimaryContactNumber = cDal.GetPersonPhoneByPersonId(p.Id).FirstOrDefault().Value;




            foreach (var a in addresses)
            {
                myBuddyProfile.PersonAddress.Add(new Address { City = a.City, CountryId = a.CountryId, CreatedOn = a.CreatedOn, Id = a.Id, Landmark = a.Landmark, Line1 = a.Line1, Line2 = a.Line2, PostCode = a.Postcode, State = a.State, Type = new BGO.Common.AddressType() { Id = a.AddressType.Id, Name = a.AddressType.Name } });
            }

            foreach (var a in phones)
            {
                myBuddyProfile.PersonContactNumber.Add(new Contact() { Id = a.Id, CreatedOn = a.CreatedOn, Type = new ContactNumberType() { Id = a.Type.Id, Name = a.Type.Name }, Value = a.Value });
            }

            foreach (var a in emails)
            {
                myBuddyProfile.PersonEmail.Add(new EmailAddress() { Id = a.Id, DateCreated = a.CreatedOn, Type = new BGO.Common.EmailType() { Id = a.Type.Id, Name = a.Type.Name }, Value = a.Value });
            }

            myBuddyProfile.PrimaryContactNumber = myBuddyProfile.PrimaryContactNumber == null ? "000000000000" : myBuddyProfile.PrimaryContactNumber;

            return View("myBuddyProfile", myBuddyProfile);
        }


        public ActionResult MyPlanner()
        {
            ViewBag.Message = "MyPlanner";
            ViewBag.Title = "MyPlanner";
            return View();
        }

        public ActionResult ChangePassword()
        {
            ViewBag.Message = "Change Password";
            ViewBag.Title = "Change Password";
            return View(new ChangePassword() { loginId = sm.UserSession.LoginId });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMyPassword(ChangePassword pVM)
        {
            if (ModelState.IsValid)
            {
                if (Helpers.BGHelper.ComputeHash(pVM.Password) == sm.UserSession.Password)
                {
                    if (Helpers.BGHelper.ComputeHash(pVM.NewPassword) == sm.UserSession.Password)
                    {
                        ModelState.AddModelError("", "old password and new password cannot be same");
                    }
                    else
                    {
                        sDal.UpdateUserLogin(pVM.loginId, "Password", Helpers.BGHelper.ComputeHash(pVM.NewPassword));
                        ViewBag.Result = "Your password has been changed successfully";
                        sDal.LogMe("TRACKING", "PASSWORD HAS BEEN CHANGED", sm.UserSession.Person.Id);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "old password is not correct");
                }
            }

            return View("ChangePassword", new ChangePassword() { loginId = sm.UserSession.LoginId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMyProfile(PersonViewModel pVM)
        {
            if (ModelState.IsValid)
            {
                cDal.UpdatePerson(pVM.FirstName, string.IsNullOrEmpty(pVM.MiddleName) ? string.Empty : pVM.MiddleName, pVM.LastName, pVM.Id, Int16.Parse(pVM.GenderTypeId), pVM.DOB.Value, Int16.Parse(pVM.SalutationTypeId));
                sm.UserSession.Person = cDal.GetPersonByPersonId(pVM.Id);
                sDal.LogMe("TRACKING", "PROFILE HAS BEEN UPDATED", sm.UserSession.Person.Id);
            }
            return RedirectToAction("MyProfile", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateMyBuddyProfile(PersonViewModel pVM)
        {
            if (ModelState.IsValid)
            {
                var p = cDal.GetPersonByPersonId(pVM.Id);

                if (p.Group == null)
                {
                    throw new Exception("unauthorized buddy profile has been accessed");
                }

                if (p.GroupId != sm.UserSession.Person.Id)
                {
                    throw new Exception("unauthorized buddy profile has been accessed");
                }

                cDal.UpdatePerson(pVM.FirstName, string.IsNullOrEmpty(pVM.MiddleName) ? string.Empty : pVM.MiddleName, pVM.LastName, pVM.Id, Int16.Parse(pVM.GenderTypeId), pVM.DOB.Value, Int16.Parse(pVM.SalutationTypeId));
                sDal.LogMe("TRACKING", "BUDDY PROFILE HAS BEEN UPDATED", sm.UserSession.Person.Id);
            }

            return RedirectToAction("MyBuddyList", "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfilePic(PhotoViewModel pVM)
        {
            if (ModelState.IsValid)
            {
                if (pVM.FileToUpload != null)
                {
                    SaveProfilePic(sm.UserSession.Person.Id, pVM.FileToUpload);

                    cDal.SavePersonUpload(sm.UserSession.Person.Id, 1, Path.Combine("ProfilePicture", $"BG-{sm.UserSession.Person.Id}", pVM.FileToUpload.FileName));

                    sDal.LogMe("TRACKING", "PROFILE PIC HAS BEEN UPDATED", sm.UserSession.Person.Id);
                }
            }

            return RedirectToAction("Index", "Account");
        }


        private void SaveProfilePic(int id, HttpPostedFileBase fileToUpload)
        {
            if (Helpers.MyHelpers.ValidateFileBeforeUpload(fileToUpload, 1024 * 1024 * 3, ".jpg,.gif,.png"))
            {
                string memberFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["upload"] + "ProfilePicture", $"BG-{sm.UserSession.Person.Id}");
                if (Directory.Exists(memberFolder) == false)
                {
                    Directory.CreateDirectory(memberFolder);
                }
                var fullPath = Path.Combine(memberFolder, fileToUpload.FileName);
                fileToUpload.SaveAs(fullPath);
            }
        }

        public JsonResult AddNewEmail(string emailValue, int? personId)
        {
            int rtn = 0;
            try
            {
                if (cDal.GetPersonByEmailAddress(emailValue).Id == 0)
                {
                    rtn = cDal.SavePersonEmail(personId.HasValue ? personId.Value : sm.UserSession.Person.Id, new PersonEmail() { CreatedOn = DateTime.Now, Value = emailValue, Type = new BGO.Contact.EmailType() { Id = 2, Name = "OFFICIAL" } });

                    sDal.LogMe("TRACKING", "NEW EMAIL ADDRESS HAS BEEN ADDED", sm.UserSession.Person.Id);
                }
                else
                {
                    rtn = 0;
                }
            }
            catch (Exception ex)
            {
                rtn = 0;
            }

            if (personId.Value != sm.UserSession.Person.Id)
            {
                rtn = 0;
            }

            return Json(rtn);
        }

        public JsonResult AddNewAddress(int addressTypeId, string line1, string line2, string city, string state, string postcode, int? personId)
        {
            int rtn = 0;
            try
            {
                rtn = cDal.SavePersonAddress(personId.HasValue ? personId.Value : sm.UserSession.Person.Id, new PersonAddress()
                {
                    Line1 = line1,
                    Line2 = line2,
                    City = city,
                    State = state,
                    CreatedOn = DateTime.Now,
                    Postcode = postcode,
                    AddressType = new BGO.Contact.AddressType() { Id = addressTypeId },
                    CountryId = 234,
                    PersonId = sm.UserSession.Person.Id,
                    Landmark = string.Empty
                });

                sDal.LogMe("TRACKING", "NEW ADDRESS HAS BEEN ADDED", sm.UserSession.Person.Id);
            }
            catch (Exception ex)
            {
                rtn = 0;
            }

            if (personId.Value != sm.UserSession.Person.Id)
            {
                rtn = 0;
            }


            return Json(rtn);
        }

        public JsonResult AddNewPhone(int phoneTypeId, string phone, int? personId)
        {
            int rtn = 0;
            try
            {
                cDal.SavePersonPhone(personId.HasValue ? personId.Value : sm.UserSession.Person.Id, new PersonPhone()
                {
                    CreatedOn = DateTime.Now,
                    Value = phone,
                    Type = new PhoneType() { Id = phoneTypeId }
                });

                sDal.LogMe("TRACKING", "NEW CONTACT NUMBER HAS BEEN ADDED", sm.UserSession.Person.Id);
            }
            catch (Exception ex)
            {
                rtn = 0;
            }

            if (personId.Value != sm.UserSession.Person.Id)
            {
                rtn = 0;
            }

            return Json(rtn);
        }

        public ActionResult MyInbox()
        {
            ViewBag.Message = "My Inbox";
            ViewBag.Title = "My Inbox";
            return View();
        }

    }
}