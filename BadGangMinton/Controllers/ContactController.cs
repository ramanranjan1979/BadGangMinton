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

        public ActionResult Edit(int personId)
        {
            var person = cDal.GetPersonByPersonId(personId);

            ViewBag.Message = $"{person.Fname} Profile";
            ViewBag.Title = $"{person.Fname} Profile";

            PersonViewModel personProfile = new PersonViewModel()
            {
                Id = personId,
                FirstName = person.Fname,
                MiddleName = person.Mname,
                LastName = person.Lname,
                DOB = person.DOB.Date,
                DateCreated = person.CreatedOn,
                GenderTypeId = person.GenderId.ToString(),
                SalutationTypeId = person.SalutationId.ToString(),
                GroupId = person.GroupId
            };

            List<BGO.Common.GenderType> genderTypes = new List<BGO.Common.GenderType>();
            List<Salutation> salutationTypes = new List<Salutation>();

            genderTypes.Add(new BGO.Common.GenderType() { Id = 1, Name = "Male" });
            genderTypes.Add(new BGO.Common.GenderType { Id = 2, Name = "Female" });

            salutationTypes = lookupDal.GetAllSalutation();
            personProfile.Gender = new SelectList(genderTypes, "Id", "Name");
            personProfile.Salutations = new SelectList(salutationTypes, "Id", "Name");

            personProfile.PersonAddress = new List<Address>();
            personProfile.PersonContactNumber = new List<Contact>();
            personProfile.PersonEmail = new List<EmailAddress>();

            var addresses = cDal.GetPersonAddressesByPersonId(personId);
            var phones = cDal.GetPersonPhoneByPersonId(personId);
            var emails = cDal.GetPersonEmailByPersonId(personId);

            if (cDal.GetPersonEmailByPersonId(personId).Where(x => x.Type.Id == 1).Count() > 0)
                personProfile.PrimaryEmail = cDal.GetPersonEmailByPersonId(personId).Where(x => x.Type.Id == 1).FirstOrDefault().Value;

            if (cDal.GetPersonPhoneByPersonId(personId).Where(x => x.Type.Id == 1).Count() > 0)
                personProfile.PrimaryContactNumber = cDal.GetPersonPhoneByPersonId(personId).FirstOrDefault().Value;


            foreach (var a in addresses)
            {
                personProfile.PersonAddress.Add(new Address
                {
                    City = a.City,
                    CountryId = a.CountryId,
                    CreatedOn = a.CreatedOn,
                    Id = a.Id,
                    Landmark = a.Landmark,
                    Line1 = a.Line1,
                    Line2 = a.Line2,
                    PostCode = a.Postcode,
                    State = a.State,
                    Type = new AddressType() { Id = a.AddressType.Id, Name = a.AddressType.Name }
                });
            }

            foreach (var a in phones)
            {
                personProfile.PersonContactNumber.Add(new Contact()
                {
                    Id = a.Id,
                    CreatedOn = a.CreatedOn,
                    Type = new ContactNumberType() { Id = a.Type.Id, Name = a.Type.Name },
                    Value = a.Value
                });
            }

            foreach (var a in emails)
            {
                personProfile.PersonEmail.Add(new EmailAddress()
                {
                    Id = a.Id,
                    DateCreated = a.CreatedOn,
                    Type = new EmailType() { Id = a.Type.Id, Name = a.Type.Name },
                    Value = a.Value
                });
            }

            personProfile.PrimaryContactNumber = personProfile.PrimaryContactNumber == null ? "000000000000" : personProfile.PrimaryContactNumber;

            return View(personProfile);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UpdateProfile(PersonViewModel pVM)
        {
            if (ModelState.IsValid)
            {
                cDal.UpdatePerson(pVM.FirstName, string.IsNullOrEmpty(pVM.MiddleName) ? string.Empty : pVM.MiddleName, pVM.LastName, pVM.Id, Int16.Parse(pVM.GenderTypeId), pVM.DOB.Value, Int16.Parse(pVM.SalutationTypeId));
                sDal.LogMe("TRACKING", $"{pVM.FirstName} {pVM.LastName} : {pVM.Id}PROFILE HAS BEEN UPDATED", sm.UserSession.Person.Id);
            }
            return RedirectToAction("Edit", new { personId = pVM.Id });
        }
        public ActionResult Details(int personId)
        {
            return View();
        }

    }
}