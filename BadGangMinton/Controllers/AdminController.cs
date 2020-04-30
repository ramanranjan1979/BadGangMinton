using BadGangMinton.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.Controllers
{
    [AuthLogin(AccountType = "sysadmin")]
    public class AdminController : BaseController
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }

    [AuthLogin(AccountType = "player")]
    public class MemberController : BaseController
    {
        
    }
}