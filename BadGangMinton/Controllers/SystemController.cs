using BadGangMinton.View.Model;
using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.Controllers
{
    public class SystemController : AdminController
    {

        public ActionResult KeyList()
        {
            return View();
        }

        public ActionResult Health(int? logTypeId, int? personId)
        {
            var data = new List<BGO.Common.Log>();

            if (logTypeId.HasValue && personId.HasValue)
            {
                if (personId.Value == -1)
                {
                    data = lookupDal.GetSystemLog().Where(x => x.LogType.Id == logTypeId.Value && x.Person == null).ToList();
                }
                else
                {
                    data = lookupDal.GetSystemLog().Where(x => x.LogType.Id == logTypeId.Value && x.Person != null && x.Person.Id == personId.Value).ToList();
                }
            }
            return View(data);
        }

        public ActionResult Usermanagement()
        {
            List<UserManagementViewModel> uVM = new List<UserManagementViewModel>();
            var data = sDal.GetLogins();
            foreach (var l in data)
            {
                uVM.Add(new UserManagementViewModel()
                {
                    Id = l.Id,
                    CreatedOn = l.CreatedOn,
                    IsActive = l.IsActive,
                    IsLock = l.IsLock,
                    LockedOn = l.LockedOn,
                    ModifiedOn = l.ModifiedOn,
                    Password = l.Password,
                    UserName = l.UserName,
                    Person = cDal.GetPersonByPersonId(l.Person.Id)
                });
            }
            return View(uVM);
        }

        public JsonResult GetLoginList()
        {
            List<UserManagementViewModel> uVM = new List<UserManagementViewModel>();
            var data = sDal.GetLogins();
            foreach (var l in data)
            {
                uVM.Add(new UserManagementViewModel()
                {
                    Id = l.Id,
                    CreatedOn = l.CreatedOn,
                    IsActive = l.IsActive,
                    IsLock = l.IsLock,
                    LockedOn = l.LockedOn,
                    ModifiedOn = l.ModifiedOn,
                    Password = l.Password,
                    UserName = l.UserName,
                    Person = cDal.GetPersonByPersonId(l.Person.Id)
                });
            }
            return Json(uVM.ToList(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult SystemHealthFilter()
        {
            LogFilterViewModel vm = new LogFilterViewModel();

            List<Person> people = new List<Person>();
            List<BGO.Common.LogType> logTypes = new List<BGO.Common.LogType>();

            people = cDal.GetPeople().OrderBy(x => x.Name).ToList();

            people.Add(new Person() { Id = -1, Fname = "NULL", Lname = "NULL" });
            logTypes = lookupDal.GetAllLogType();


            vm.People = new SelectList(people, "Id", "Name");
            vm.LogTypes = new SelectList(logTypes, "Id", "Name");

            return PartialView("_systemHealthFilter", vm);
        }
    }
}