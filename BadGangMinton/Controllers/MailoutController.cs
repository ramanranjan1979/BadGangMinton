using BadGangMinton.View.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.Controllers
{
    public class MailoutController : AdminController
    {

        public ActionResult Templates()
        {
            List<BGO.Common.MailoutType> mxTypes = lookupDal.GetAllMailoutType();

            foreach (var mx in mxTypes)
            {
                try
                {
                    mx.HtmlBody = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + $"{mx.Name}.html");
                }
                catch (Exception ex)
                {
                    mx.HtmlBody = "Template not found";
                }
            }
            return View(mxTypes);
        }

        [HttpPost]
        public JsonResult GetMxTemplateByMailoutTypeId(int mailoutTypeId)
        {
            List<BGO.Common.MailoutType> mxTypes = lookupDal.GetAllMailoutType().Where(x => x.Id == mailoutTypeId).ToList();
            foreach (var mx in mxTypes)
            {
                mx.HtmlBody = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + $"{mx.Name}.html");
            }

            return Json(new { html = mxTypes.Where(x => x.Id == mailoutTypeId).FirstOrDefault().HtmlBody });
        }


        public ActionResult History()
        {
            return View("MailoutList");
        }

        public ActionResult ComposeEmail()
        {
            MailoutCompose vModel = new MailoutCompose()
            {
                From = sm.UserSession.Person.PersonEmail.Where(x => x.Type.Id == 1).FirstOrDefault().Value
            };

            vModel.People = new SelectList(cDal.GetPeople(), "Id", "Name");
            return View(vModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SendNotification(MailoutCompose notification)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in notification.PersonId)
                {

                    Dictionary<string, string> param = new Dictionary<string, string>();
                    param.Add("NAME", cDal.GetPersonByPersonId(int.Parse(item)).Fname);
                    param.Add("Message", notification.Body);

                    string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpDefault.html", param);

                    var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 6).FirstOrDefault();

                    string toEmail = cDal.GetPersonEmailByPersonId(int.Parse(item)).Where(x => x.Type.Id == 1).FirstOrDefault().Value;

                    var q = mxDAL.PushNotification(cDal.GetPersonByPersonId(int.Parse(item)), param, mxType.Id, toEmail, html);

                    var res = emailService.EmailBySMTP(toEmail, ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);

                    if (res.HasError)
                    {
                        sDal.LogMe("EMAILEXCEPTION", $"EMAIL EXCEPTION: {res.ErrorMessage}", int.Parse(item));

                        mxDAL.UpdateNotification(q.Id);
                    }
                }

                return RedirectToAction("ComposeEmail");
            }

            return RedirectToAction("ComposeEmail");
        }

        public ActionResult GetNotificationPreview(string content)
        {
            StringBuilder sb = new StringBuilder();
            var rawString = System.IO.File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpDefault.html");
            rawString = rawString.Replace("{#NAME#}", sm.UserSession.Person.Fname);
            rawString = rawString.Replace("{#MESSAGE#}", content);
            return Json(rawString);
        }

        public ActionResult SendTestNotification(string content, string toEmail, string subject)
        {
            if (!string.IsNullOrEmpty(toEmail) && !string.IsNullOrEmpty(content) && !string.IsNullOrEmpty(subject))
            {
                Dictionary<string, string> param = new Dictionary<string, string>();
                param.Add("NAME", sm.UserSession.Person.Fname);
                param.Add("Message", content);

                string html = bgService.GetHtml(AppDomain.CurrentDomain.BaseDirectory + ConfigurationManager.AppSettings["mxTemplatePath"] + "tmpDefault.html", param);
                var mxType = lookupDal.GetAllMailoutType().Where(x => x.Id == 6).FirstOrDefault();
                var res = emailService.EmailBySMTP(toEmail, ConfigurationManager.AppSettings["SMTP_FROM"], html, mxType.Subject);
            }
            return Json("DONE");
        }


        public JsonResult Resend(int? mailoutQueueId)
        {
            var queue = mxDAL.GetMailoutQueueById(mailoutQueueId.Value);
            var res = emailService.EmailBySMTP(queue.Email, ConfigurationManager.AppSettings["SMTP_FROM"], queue.HTML, queue.Subject);
            sDal.LogMe("TRACKING", $"Email subjecting: {queue.Subject} has been resent", queue.Person.Id);
            return Json("DONE");
        }



    }
}