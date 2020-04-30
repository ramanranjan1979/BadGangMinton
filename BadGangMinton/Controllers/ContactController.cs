using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BadGangMinton.View.Model;
using BGO.Common;
using BadGangMinton.Helpers;

namespace BadGangMinton.Controllers
{
    public class ContactController : AdminController
    {

        public ActionResult ContactList()
        {
            var data = cDal.GetPeople();
            return View(data);
        }

        public ActionResult EnquiryList()
        {
            var data = cDal.GetPeople(false);
            return View(data);
        }

        public ActionResult Add()
        {
            PersonViewModel model = new PersonViewModel();

            List<BGO.Common.GenderType> genderTypes = new List<BGO.Common.GenderType>();
            List<Salutation> salutationTypes = new List<Salutation>();

            genderTypes.Add(new BGO.Common.GenderType() { Id = 1, Name = "Male" });
            genderTypes.Add(new BGO.Common.GenderType { Id = 2, Name = "Female" });

            salutationTypes = lookupDal.GetAllSalutation();
            model.Gender = new SelectList(genderTypes, "Id", "Name");
            model.Salutations = new SelectList(salutationTypes, "Id", "Name");
            return View(model);
        }

       

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewPerson(PersonViewModel pVM)
        {
            if (ModelState.IsValid)
            {

                BGO.Contact.Person p = new BGO.Contact.Person()
                {
                    CreatedOn = DateTime.Now,
                    DOB = pVM.DOB.Value,
                    Fname = pVM.FirstName,
                    Mname = pVM.MiddleName,
                    Lname = pVM.LastName,
                    IsActive = true,
                    GenderId = Int16.Parse(pVM.GenderTypeId),
                    SalutationId = Int16.Parse(pVM.SalutationTypeId),
                    IPaddress = GetUserIp(),
                    GroupId = pVM.GroupId == 0 ? null : pVM.GroupId

                };

                BGO.Contact.PersonEmail pe = new BGO.Contact.PersonEmail()
                {
                    Type = new BGO.Contact.EmailType() { Id = 1, Name = "PERSONAL" },
                    Value = pVM.PrimaryEmail
                };

                BGO.Contact.PersonPhone ph = new BGO.Contact.PersonPhone()
                {
                    Type = new BGO.Contact.PhoneType() { Id = 1, Name = "MOBILE" },
                    Value = pVM.PrimaryContactNumber
                };

                int newPersonId = cDal.SavePerson(p);

                int newPersonEmailId = cDal.SavePersonEmail(newPersonId, pe);

                int newPersonPhoneId = cDal.SavePersonPhone(newPersonId, ph);

                sDal.LogMe("TRACKING", "NEW CONTACT HAS BEEN ADDED", sm.UserSession.Person.Id);

                return RedirectToAction("ContactList");
            }

            return RedirectToAction("Add");
        }


        public ActionResult GetContactDetails(int personId)
        {
            var contact = cDal.GetPersonByPersonId(personId);
            contact.PersonEmail = cDal.GetPersonEmailByPersonId(personId);
            contact.PersonPhone = cDal.GetPersonPhoneByPersonId(personId);
            contact.PersonAddress = cDal.GetPersonAddressesByPersonId(personId);
            contact.Group = contact.GroupId.HasValue ? cDal.GetPersonByPersonId(contact.GroupId.Value) : null;
            return Content(Newtonsoft.Json.JsonConvert.SerializeObject(contact), "application/json");
        }

    }
}