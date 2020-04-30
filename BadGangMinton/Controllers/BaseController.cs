using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BadGangMinton.DAL;
using BadGangMinton.View.Model;
using BadGangMinton.Session;
using System.Configuration;

namespace BadGangMinton.Controllers
{
    public class BaseController : Controller
    {
        protected LookupDal lookupDal = new LookupDal();
        protected ContactDal cDal = new ContactDal();
        protected SecurityDal sDal = new SecurityDal();
        protected MemberDal mDal = new MemberDal();
        protected TransactionDal txDAL = new TransactionDal();
        protected MxDal mxDAL = new MxDal();
        protected SessionManager sm = new SessionManager();
        protected Helpers.BGService bgService = new Helpers.BGService();
        protected Helpers.EmailService emailService = new Helpers.EmailService(bool.Parse(ConfigurationManager.AppSettings["TESTMODE"]), System.Web.HttpContext.Current);

        [HttpPost]
        public JsonResult DoesEmailExist(string PrimaryEmail)
        {
            return Json(cDal.GetPersonByEmailAddress(PrimaryEmail).Id == 0);
        }

        [HttpPost]
        public JsonResult DoesUserNameExist(string userName)
        {
            if (string.IsNullOrEmpty(userName))
            {
                return Json(false);
            }

            return Json(sDal.GetPersonByUserName(userName.ToLower()).Id == 0);
        }

        public string GetUserIp()
        {
            var UserIPAddress = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(UserIPAddress))
            {
                UserIPAddress = Request.ServerVariables["REMOTE_ADDR"];
            }

            return UserIPAddress;
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            var exceptionDetails = filterContext.Exception.InnerException == null ? $"Exception:{filterContext.Exception.ToString()}" : $"Exception:{filterContext.Exception.ToString()}#InnerException{filterContext.Exception.InnerException.ToString()}";

            int? mid = null;
            string redirectTO = string.Empty;

            if (new SessionManager().UserSession != null)
            {
                mid = new int();
                mid = new SessionManager().UserSession.Person.Id;
            }

            sDal.LogMe("EXCEPTION", exceptionDetails, mid);

            filterContext.ExceptionHandled = true;
            var model = new HandleErrorInfo(filterContext.Exception, "Controller", "Action");

            //filterContext.Result = RedirectToAction("Login", "Account", new { navTo = redirectTO });

            filterContext.Result = new ViewResult()
            {
                ViewName = "~/Views/Error/Error.cshtml",
                ViewData = new ViewDataDictionary(exceptionDetails)
            };
        }
    }
}