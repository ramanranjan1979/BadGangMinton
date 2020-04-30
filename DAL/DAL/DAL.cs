using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DB;
using System.Security.Cryptography;
using System.Data.Entity;
using BGO.Contact;
using BGO.Mailout;
using BGO.Security;
using System.IO;

namespace BadGangMinton.DAL
{
    public class LookupDal : bgDBContainer
    {


        public List<BGO.Common.AddressType> GetAllAddressType()
        {
            List<BGO.Common.AddressType> lookupData = new List<BGO.Common.AddressType>();
            var persontype = (from x in PersonType select x).ToList();
            foreach (var type in AddressType)
            {
                lookupData.Add(new BGO.Common.AddressType()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }

            return lookupData;
        }

        public List<BGO.Common.ContactNumberType> GetAllContactNumberType()
        {
            List<BGO.Common.ContactNumberType> lookupData = new List<BGO.Common.ContactNumberType>();
            var types = (from x in PhoneType select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.ContactNumberType()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }

            return lookupData;
        }

        public List<BGO.Common.Country> GetAllCountry()
        {
            List<BGO.Common.Country> lookupData = new List<BGO.Common.Country>();

            var countries = (from x in Country select x).ToList();

            foreach (var country in countries)
            {
                lookupData.Add(new BGO.Common.Country()
                {
                    Id = country.Id,
                    CountryCode = country.CountryCode,
                    EnglishName = country.EnglishName,
                    IsActive = country.IsActive
                });
            }
            return lookupData;
        }

        public List<BGO.Common.EmailType> GetAllEmailAddressType()
        {
            List<BGO.Common.EmailType> lookupData = new List<BGO.Common.EmailType>();
            var types = (from x in EmailType select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.EmailType()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }
            return lookupData;
        }

        public List<BGO.Common.JobTitle> GetAllJobTitle()
        {
            List<BGO.Common.JobTitle> lookupData = new List<BGO.Common.JobTitle>();
            var types = (from x in JobTitle select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.JobTitle()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }
            return lookupData;
        }

        public List<BGO.Common.Occupation> GetAllOccupation()
        {
            List<BGO.Common.Occupation> lookupData = new List<BGO.Common.Occupation>();
            var types = (from x in Occupation select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.Occupation()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }
            return lookupData;
        }

        public List<BGO.Common.LogType> GetAllLogType()
        {
            List<BGO.Common.LogType> lookupData = new List<BGO.Common.LogType>();
            var types = (from x in LogType select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.LogType()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }
            return lookupData;
        }

        public List<BGO.Common.PersonType> GetAllPersonType()
        {
            List<BGO.Common.PersonType> lookupData = new List<BGO.Common.PersonType>();
            var types = (from x in PersonType select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.PersonType()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }

            return lookupData;
        }

        public List<BGO.Common.Salutation> GetAllSalutation()
        {
            List<BGO.Common.Salutation> lookupData = new List<BGO.Common.Salutation>();
            var types = (from x in Salutation select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.Salutation()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }

            return lookupData;
        }

        public List<BGO.Common.UploadType> GetAllUploadType()
        {
            List<BGO.Common.UploadType> lookupData = new List<BGO.Common.UploadType>();
            var types = (from x in UploadType select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.UploadType()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }

            return lookupData;
        }

        public List<BGO.Common.SocialProfileType> GetAllSocialProfileType()
        {
            List<BGO.Common.SocialProfileType> lookupData = new List<BGO.Common.SocialProfileType>();
            var types = (from x in UploadType select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.SocialProfileType()
                {
                    Id = type.Id,
                    Name = type.Name
                });
            }

            return lookupData;
        }

        public List<BGO.Common.TransactionType> GetAllTransactionType()
        {
            List<BGO.Common.TransactionType> lookupData = new List<BGO.Common.TransactionType>();
            var types = (from x in TransactionType select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.TransactionType()
                {
                    Id = type.Id,
                    Name = type.Code,
                    Multiplier = type.Multiplier,
                    Desc = type.Description
                });
            }

            return lookupData;
        }

        public List<BGO.Common.Log> GetSystemLog()
        {
            List<BGO.Common.Log> lookupData = new List<BGO.Common.Log>();
            var types = (from x in Log select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.Log()
                {
                    CreatedOn = type.CreatedOn,
                    Description = type.Description,
                    Id = type.Id,
                    Person = type.PersonId.HasValue ? new ContactDal().GetPersonByPersonId(type.PersonId.Value) : null,
                    LogType = GetAllLogType().Where(x => x.Id == type.LogTypeId).FirstOrDefault()
                });
            }

            return lookupData;
        }

        public List<BGO.Common.Log> GetPersonLog(int personId)
        {
            List<BGO.Common.Log> lookupData = new List<BGO.Common.Log>();
            var types = (from x in Log where x.PersonId == personId select x).ToList();
            foreach (var type in types)
            {
                lookupData.Add(new BGO.Common.Log()
                {
                    CreatedOn = type.CreatedOn,
                    Description = type.Description,
                    Id = type.Id,
                    Person = type.PersonId.HasValue ? new ContactDal().GetPersonByPersonId(type.PersonId.Value) : null,
                    LogType = GetAllLogType().Where(x => x.Id == type.LogTypeId).FirstOrDefault()
                });
            }

            return lookupData;
        }

        public List<BGO.Common.MailoutType> GetAllMailoutType()
        {
            List<BGO.Common.MailoutType> lookupData = new List<BGO.Common.MailoutType>();
            var type = (from x in MailoutType select x).ToList();
            foreach (var t in type)
            {
                lookupData.Add(new BGO.Common.MailoutType()
                {
                    Id = t.Id,
                    Name = t.Name,
                    Subject = t.Subject,
                    Description = t.Description

                });
            }

            return lookupData;
        }


    }

    public class ContactDal : bgDBContainer
    {
        public BGO.Contact.Person GetPersonByPersonId(int personId)
        {
            var PE = (from x in Person where x.Id == personId select x).FirstOrDefault();
            BGO.Contact.Person data = new BGO.Contact.Person()
            {
                Id = PE.Id,
                Fname = PE.Fname,
                Mname = PE.Mname,
                Lname = PE.Lname,
                CreatedOn = PE.CreatedOn,
                DOB = PE.DOB,
                GenderId = PE.GenderId,
                IsActive = PE.IsActive,
                SalutationId = PE.SalutationId,
                GroupId = PE.GroupID,
                Group = PE.GroupID.HasValue ? GetPersonByPersonId(PE.GroupID.Value) : null
            };

            return data;
        }

        public List<BGO.Contact.PersonEmail> GetPersonEmailByPersonId(int personId)
        {
            List<BGO.Contact.PersonEmail> personEmail = new List<BGO.Contact.PersonEmail>();
            var PE = (from x in PersonEmail where x.PersonId == personId select x).ToList();
            PE.ForEach(x => personEmail.Add(new BGO.Contact.PersonEmail() { Id = x.Id, CreatedOn = x.CreatedOn, Value = x.Value, Type = new BGO.Contact.EmailType() { Id = x.EmailType.Id, Name = x.EmailType.Name } }));
            return personEmail;
        }

        public List<BGO.Contact.PersonUpload> GetPersonUploadyPersonId(int personId)
        {
            List<BGO.Contact.PersonUpload> personUpload = new List<BGO.Contact.PersonUpload>();
            var PE = (from x in PersonUpload where x.PersonId == personId select x).ToList();
            PE.ForEach(x => personUpload.Add(new BGO.Contact.PersonUpload()
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Path = x.Path,
                Type = new BGO.Contact.UploadType()
                {
                    Id = x.UploadType.Id,
                    Name = x.UploadType.Name
                }
            }));
            return personUpload;
        }


        public List<BGO.Contact.PersonPhone> GetPersonPhoneByPersonId(int personId)
        {
            List<BGO.Contact.PersonPhone> personPhones = new List<BGO.Contact.PersonPhone>();
            var PH = (from x in PersonPhone where x.PersonId == personId select x).ToList();
            PH.ForEach(x => personPhones.Add(new BGO.Contact.PersonPhone() { CreatedOn = x.CreatedOn, Id = x.Id, Value = x.Value, Type = new BGO.Contact.PhoneType() { Id = x.PhoneType.Id, Name = x.PhoneType.Name } }));
            return personPhones;
        }


        public BGO.Contact.Person GetPersonByEmailAddress(string emailAddress)
        {
            BGO.Contact.Person p = new BGO.Contact.Person();
            var PE = (from x in PersonEmail where x.Value.ToLower() == emailAddress.ToLower() select x).FirstOrDefault();
            if (PE != null)
                p = GetPersonByPersonId(PE.PersonId);
            return p;
        }

        public List<BGO.Contact.PersonAddress> GetPersonAddressesByPersonId(int personId)
        {
            List<BGO.Contact.PersonAddress> personAddress = new List<BGO.Contact.PersonAddress>();
            var PH = (from x in PersonAddress where x.PersonId == personId select x).ToList();
            PH.ForEach(x => personAddress.Add(new BGO.Contact.PersonAddress()
            {
                Line1 = x.Line1,
                Line2 = x.Line2,
                City = x.City,
                State = x.State,
                Postcode = x.Postcode,
                AddressType = new BGO.Contact.AddressType() { Id = x.AddressType.Id, Name = x.AddressType.Name },
                CountryId = x.CountryId,
                Id = x.Id,
                CreatedOn = x.CreatedOn,
                Landmark = x.Landmark,
                PersonId = x.PersonId
            }));
            return personAddress;
        }

        public List<BGO.Contact.Person> GetPeople(bool status = true)
        {
            List<BGO.Contact.Person> lookupData = new List<BGO.Contact.Person>();
            var People = (from x in Person where x.IsActive == status select x).ToList();
            foreach (var p in People)
            {
                lookupData.Add(new BGO.Contact.Person()
                {
                    Fname = p.Fname,
                    Mname = p.Mname,
                    Lname = p.Lname,
                    Id = p.Id,
                    CreatedOn = p.CreatedOn,
                    DOB = p.DOB,
                    GenderId = p.GenderId,
                    IsActive = p.IsActive,
                    SalutationId = p.SalutationId,
                    PersonEmail = GetPersonEmailByPersonId(p.Id),
                    PersonPhone = GetPersonPhoneByPersonId(p.Id),
                    GroupId = p.GroupID
                });
            }

            return lookupData;
        }

        public void UpdatePerson(string fname, string mname, string lname, int personId, Int16 genderId, DateTime dob, int salutationId)
        {
            var p = (from x in Person where x.Id == personId select x).FirstOrDefault();
            p.Fname = fname;
            p.Mname = string.IsNullOrEmpty(mname) ? string.Empty : mname;
            p.Lname = lname;
            p.GenderId = genderId;
            p.DOB = dob;
            p.SalutationId = salutationId;
            p.IsActive = true;
            Person.Attach(p);
            Entry(p).State = EntityState.Modified;
            SaveChanges();

        }

        public int SavePerson(BGO.Contact.Person p)
        {
            DB.Person newPerson = new DB.Person()
            {
                Fname = p.Fname,
                Mname = string.IsNullOrEmpty(p.Mname) ? string.Empty : p.Mname,
                Lname = p.Lname,
                Id = p.Id,
                CreatedOn = p.CreatedOn,
                DOB = p.DOB,
                GenderId = p.GenderId,
                IsActive = p.IsActive,
                SalutationId = p.SalutationId,
                IPAddress = p.IPaddress,
                GroupID = p.GroupId
            };
            Person.Add(newPerson);
            SaveChanges();
            return newPerson.Id;
        }

        public int SavePersonEmail(int personId, BGO.Contact.PersonEmail pe)
        {
            DB.PersonEmail newPersonEmail = new DB.PersonEmail
            {
                Person = (from x in Person where x.Id == personId select x).FirstOrDefault(),
                CreatedOn = DateTime.Now,
                //EmailType = new DB.EmailType() {Id=pe.Type.Id,Name=pe.Type.Name },
                Value = pe.Value,
                EmailTypeId = pe.Type.Id

            };
            PersonEmail.Add(newPersonEmail);
            SaveChanges();
            return newPersonEmail.Id;
        }

        public int SavePersonPhone(int personId, BGO.Contact.PersonPhone ph)
        {

            DB.PersonPhone newPersonPhone = new DB.PersonPhone
            {
                Person = (from x in Person where x.Id == personId select x).FirstOrDefault(),
                CreatedOn = DateTime.Now,
                //PhoneType = new DB.PhoneType() { Id = ph.Type.Id, Name = ph.Type.Name },
                Value = ph.Value,
                PhoneTypeId = ph.Type.Id

            };
            PersonPhone.Add(newPersonPhone);
            SaveChanges();
            return newPersonPhone.Id;
        }

        public int SavePersonAddress(int personId, BGO.Contact.PersonAddress pa)
        {
            DB.PersonAddress newPersonAddress = new DB.PersonAddress
            {
                Person = (from x in Person where x.Id == personId select x).FirstOrDefault(),
                CreatedOn = DateTime.Now,
                AddressTypeId = pa.AddressType.Id,
                Line1 = pa.Line1,
                Line2 = pa.Line2,
                City = pa.City,
                Landmark = pa.Landmark,
                State = pa.State,
                Postcode = pa.Postcode,
                PersonId = personId,
                CountryId = pa.CountryId
            };
            PersonAddress.Add(newPersonAddress);
            SaveChanges();
            return newPersonAddress.Id;
        }

        public void SavePersonUpload(int personId, int uploadTypeId, string path)
        {
            DB.PersonUpload newupload = new DB.PersonUpload()
            {
                CreatedOn = DateTime.Now,
                PersonId = personId,
                Path = path,
                UploadTypeId = uploadTypeId
            };
            PersonUpload.Add(newupload);
            SaveChanges();
        }

        public List<BGO.Contact.Person> GetBuddyListByPersonId(int personId)
        {
            List<BGO.Contact.Person> lookupData = new List<BGO.Contact.Person>();
            var People = (from x in Person where x.GroupID.Value == personId select x).ToList();
            foreach (var p in People)
            {
                lookupData.Add(new BGO.Contact.Person()
                {
                    Fname = p.Fname,
                    Mname = p.Mname,
                    Lname = p.Lname,
                    Id = p.Id,
                    CreatedOn = p.CreatedOn,
                    DOB = p.DOB,
                    GenderId = p.GenderId,
                    IsActive = p.IsActive,
                    SalutationId = p.SalutationId,
                    PersonEmail = GetPersonEmailByPersonId(p.Id),
                    PersonPhone = GetPersonPhoneByPersonId(p.Id),
                    GroupId = p.GroupID
                });
            }

            return lookupData;
        }
    }

    public class Security
    {
        public int LoginId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }
        public bool IsLock { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; } = null;
        public DateTime? LockedOn { get; set; } = null;

        public BGO.Contact.Person Person { get; set; }

        public List<string> RoleNameList { get; set; }
    }


    public class LoginStatus
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public string TargetURL { get; set; }
        public int memberId { get; set; }
        public Security LoggedInPerson { get; set; }
    }

    public class SecurityDal : bgDBContainer
    {
        public List<SecurityTypeCode> GetPeronSecurityCodeBySecurityType(int personId, string securityTypeName)
        {
            List<SecurityTypeCode> data = new List<SecurityTypeCode>();

            var x = (from y in SecurityCode where y.PersonId == personId && y.SecurityType.Name.ToLower() == securityTypeName.ToLower() select y).ToList();
            foreach (var item in x)
            {
                SecurityTypeCode stc = new SecurityTypeCode()
                {
                    Code = item.Code,
                    CreatedOn = item.CreatedOn,
                    ExpiredOn = item.ExpiredOn,
                    Id = item.Id,
                    Person = new ContactDal().GetPersonByPersonId(item.PersonId),
                    SecurityType = new BGO.Security.SecurityType()
                    {
                        Id = item.SecurityType.Id,
                        Name = item.SecurityType.Name
                    }
                };
                data.Add(stc);
            }

            return data;

        }

        public BGO.Contact.Person GetPersonByUserName(string userName)
        {
            BGO.Contact.Person p = new BGO.Contact.Person();
            var data = (from x in Login where x.UserName.ToLower() == userName.ToLower() select x).FirstOrDefault();
            return data == null ? p : new ContactDal().GetPersonByPersonId(data.Person.Id);
        }

        public void LogMe(string logTypeName, string msg, int? personId)
        {
            Log log = new Log() { Description = msg, PersonId = personId, CreatedOn = DateTime.Now };
            LogType _type = (from _logType in LogType where _logType.Name.ToLower() == logTypeName.ToLower() select _logType).SingleOrDefault();
            log.LogType = _type;
            Log.Add(log);
            SaveChanges();
        }

        public string RaisePersonSecurityRequest(int personId, string securityName)
        {
            var type = (from x in SecurityType where x.Name.ToLower() == securityName.ToLower() select x).FirstOrDefault();
            var p = (from x in Person where x.Id == personId select x).FirstOrDefault();

            SecurityCode sc = new SecurityCode()
            {
                Code = RandomNumberGenerator.Create().GetHashCode().ToString(),
                CreatedOn = DateTime.Now,
                SecurityType = type,
                Person = p,
                SecurityTypeId = type.Id,
                PersonId = personId
            };
            SecurityCode.Add(sc);
            SaveChanges();
            return sc.Code;
        }

        public LoginStatus ValidateUser(string userName, string password)
        {
            LoginStatus status = new LoginStatus();
            SHA1Managed sha1m = new SHA1Managed();
            var temp = sha1m.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            string passwordHash = "";
            foreach (var _byte in temp)
            {
                passwordHash = passwordHash + _byte.ToString("X2");
            }
            var userLogin = (from x in Login.Include("Person") where x.UserName == userName && x.Password == passwordHash && x.IsActive select x).SingleOrDefault();


            if (userLogin == null)
            {
                status.Success = false;
                status.Message = "Invalid Username or password";
            }
            else
            {
                status.Success = true;
                status.Message = "Login attempt successful!";
                status.LoggedInPerson = new Security()
                {
                    LoginId = userLogin.Id,
                    IsActive = userLogin.IsActive,
                    Password = userLogin.Password,
                    UserName = userLogin.UserName,
                    Person = new ContactDal().GetPersonByPersonId(userLogin.Person.Id),

                };

                status.LoggedInPerson.RoleNameList = new List<string>();
                status.LoggedInPerson.Person.PersonEmail = new ContactDal().GetPersonEmailByPersonId(userLogin.Person.Id);
                status.LoggedInPerson.Person.PersonPhone = new ContactDal().GetPersonPhoneByPersonId(userLogin.Person.Id);
                status.LoggedInPerson.Person.PersonAddress = new ContactDal().GetPersonAddressesByPersonId(userLogin.Person.Id);

                var membership = (from x in Member where x.PersonId == userLogin.Person.Id select x).ToList();

                foreach (var item in membership)
                {
                    foreach (var role in item.PersonType.PersonRole)
                    {
                        status.LoggedInPerson.RoleNameList.Add(role.Role.Name.ToLower());
                    }
                }

            }
            return status;
        }



        public void UpdateUserLogin(int loginId, string fieldName, string fieldValue = null)
        {
            var login = (from l in Login where l.Id == loginId select l).FirstOrDefault();

            if (fieldName == "LOCK")
            {
                DateTime? dt = null;
                login.IsLock = login.IsLock ? false : true;
                login.LockedOn = login.IsLock ? DateTime.Now : dt;
            }
            if (fieldName == "Password")
            {
                login.Password = fieldValue;
            }
            login.ModifiedOn = DateTime.Now;

            Login.Attach(login);
            Entry(login).State = EntityState.Modified;
            SaveChanges();


        }

        public string GenerateUserName(int personId)
        {
            string username = string.Empty;
            var p = new ContactDal().GetPersonByPersonId(personId);
            try
            {
                string tryUsername = p.Name;
                username = GetUniqueUserName(tryUsername);
            }
            catch (Exception ex)
            {
                username = Guid.NewGuid().ToString().Substring(0, 8);
            }

            return username.ToLower();
        }

        public SecurityTypeCode GetPersonSecurityCodeByCode(string code)
        {
            var data = (from x in SecurityCode where x.Code.ToLower() == code.ToLower() select x).FirstOrDefault();

            if (data == null)
                return null;

            SecurityTypeCode stc = new SecurityTypeCode()
            {
                Code = data.Code,
                CreatedOn = data.CreatedOn,
                ExpiredOn = data.ExpiredOn,
                Id = data.Id,
                Person = new ContactDal().GetPersonByPersonId(data.PersonId),
                SecurityType = new BGO.Security.SecurityType()
                {
                    Id = data.SecurityType.Id,
                    Name = data.SecurityType.Name
                }
            };

            return stc;

        }

        public void ApplyPersonSecurityCode(int personId, string code)
        {
            var data = (from x in SecurityCode where x.Code.ToLower() == code.ToLower() && x.Person.Id == personId select x).FirstOrDefault();

            if (data == null)
                throw new Exception($"PersonId {personId} and security code {code} is not found or matching");

            data.ExpiredOn = DateTime.Now;
            SecurityCode.Attach(data);
            Entry(data).State = EntityState.Modified;
            SaveChanges();
        }

        public string GetUniqueUserName(string code)
        {
            string userName = code;
            bool isDuplicate = true;

            while (isDuplicate == true)
            {
                var m = Login.Where(x => x.UserName.ToUpper() == code.ToUpper()).ToList();
                if (m.ToList().Count > 0)
                {
                    userName = string.Format("{0}{1}", userName, m.Count() + 1);
                    code = userName;
                }
                else
                {
                    isDuplicate = false;
                }
            }

            return userName;
        }

        public void SaveUserLogin(string username, string pwd, int personId)
        {
            var p = (from x in Person where x.Id == personId select x).FirstOrDefault();
            Login l = new Login()
            {
                UserName = username,
                Password = pwd,
                CreatedOn = DateTime.Now,
                IsActive = true,
                IsLock = false,
                MustChangepassword = false,
                Person = p
            };

            Login.Add(l);
            SaveChanges();

        }

        public BGO.Contact.Person ValidateSecurityCode(string code)
        {
            BGO.Contact.Person m = new BGO.Contact.Person();

            var personCode = ((from x in Person
                               join y in SecurityCode on x.Id equals y.PersonId
                               where y.Code == code && x.IsActive && y.ExpiredOn == null
                               select x).SingleOrDefault());

            var codeDetail = (from _v in SecurityCode where _v.Code.ToString() == code select _v).FirstOrDefault();

            if (personCode == null || codeDetail == null)
            {
                m = null;
            }
            else
            {
                m = new ContactDal().GetPersonByPersonId(personCode.Id);
            }

            return m;
        }

        public int ApplySecurityCode(int personId, string securityCode, string password)
        {
            DB.Login lUpdated = new DB.Login();
            SecurityCode cUpdated = new SecurityCode();

            int pid = 0;

            lUpdated = (from l in Login where l.Person.Id == personId && l.Person.IsActive select l).SingleOrDefault();

            cUpdated = (from x in SecurityCode
                        join y in Person on x.Person.Id equals y.Id
                        where x.ExpiredOn == null && y.IsActive && x.Code == securityCode && x.Person.Id == personId
                        select x).SingleOrDefault();


            if (lUpdated == null || cUpdated == null)
            {
                return pid;
            }
            else
            {
                pid = lUpdated.Person.Id;
            }

            SHA1Managed sha1m = new SHA1Managed();
            byte[] temp = sha1m.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            string passwordHash = string.Empty;
            foreach (var _byte in temp)
            {
                passwordHash = passwordHash + _byte.ToString("X2");
            }

            lUpdated.Password = passwordHash;
            lUpdated.ModifiedOn = DateTime.Now;
            Entry(lUpdated).State = EntityState.Modified;
            SaveChanges();


            cUpdated.ExpiredOn = DateTime.Now;
            Entry(cUpdated).State = EntityState.Modified;
            SaveChanges();

            return lUpdated.Id;
        }

        public void ClearPasswordVerificationtRequest(int personId)
        {
            var verifications = (from v in SecurityCode where v.Person.Id == personId && v.SecurityTypeId == 1 && v.ExpiredOn == null select v).ToList();
            if (verifications != null)
            {
                foreach (var verify in verifications)
                {
                    verify.ExpiredOn = DateTime.Now;
                    Entry(verify).State = EntityState.Modified;
                    SaveChanges();
                }
            }
        }

        public List<UserLogin> GetLogins()
        {
            List<UserLogin> lookupData = new List<UserLogin>();
            var data = (from x in Login select x).ToList();
            foreach (var l in data)
            {
                lookupData.Add(new UserLogin()
                {
                    Id = l.Id,
                    CreatedOn = l.CreatedOn,
                    IsActive = l.IsActive,
                    IsLock = l.IsLock,
                    LockedOn = l.LockedOn,
                    ModifiedOn = l.ModifiedOn,
                    Password = l.Password,
                    UserName = l.UserName,
                    Person = new ContactDal().GetPersonByPersonId(l.Person.Id)
                });
            }

            return lookupData;
        }

        public void DeleteLog(int logTypId, string description, int personId)
        {
            var logs = (from x in Log where x.LogTypeId == logTypId && x.PersonId == personId && x.Description == description select x).ToList();

            foreach (var log in logs)
            {
                Log.Attach(log);
                Entry(log).State = EntityState.Deleted;
                SaveChanges();
            }

        }
    }

    public class MemberDal : bgDBContainer
    {
        public void CreateMember(int personId, DateTime dOJ, int personTypeId, bool status = true)
        {
            DB.Member newMember = new DB.Member()
            {
                PersonId = personId,
                JoiningDate = dOJ,
                IsActive = status,
                PersonTypeId = personTypeId
            };
            Member.Add(newMember);
            SaveChanges();
        }

        public List<BGO.Member.Member> GetMember(int personTypeId)
        {
            List<BGO.Member.Member> lookupData = new List<BGO.Member.Member>();
            var members = (from x in Member where x.PersonTypeId == personTypeId select x).ToList();
            foreach (var p in members)
            {
                lookupData.Add(new BGO.Member.Member()
                {
                    Id = p.Id,
                    PersonId = p.PersonId,
                    JoiningDate = p.JoiningDate.Value,
                    IsActive = p.IsActive,
                    PersonTypeId = p.PersonTypeId,
                    Person = new ContactDal().GetPersonByPersonId(p.PersonId),
                    AccountBalance = new TransactionDal().GetAccountBalance(p.PersonId),
                    IsMembershipActive = p.Person.Logs.Where(x => x.Description == "Membership has been suspend").FirstOrDefault() == null ? true : false

                });
            }

            return lookupData;
        }

        public List<BGO.Contact.Person> GetPotentialMember(int personTypeId)
        {
            List<BGO.Contact.Person> lookupData = new List<BGO.Contact.Person>();
            var people = (from x in Person where x.IsActive select x).ToList();
            foreach (var p in people)
            {
                var member = (from x in Member where x.PersonId == p.Id && x.PersonTypeId == personTypeId select x).ToList();
                if (member.Count > 0)
                    continue;

                lookupData.Add(new BGO.Contact.Person()
                {
                    Fname = p.Fname,
                    Mname = p.Mname,
                    Lname = p.Lname,
                    Id = p.Id,
                    CreatedOn = p.CreatedOn,
                    DOB = p.DOB,
                    GenderId = p.GenderId,
                    IsActive = p.IsActive,
                    SalutationId = p.SalutationId,
                    PersonEmail = new ContactDal().GetPersonEmailByPersonId(p.Id),
                    PersonPhone = new ContactDal().GetPersonPhoneByPersonId(p.Id),
                    GroupId = p.GroupID
                });
            }

            return lookupData;
        }




    }

    public class TransactionDal : bgDBContainer
    {
        public List<BGO.TX.Transaction> GetTransaction()
        {
            List<BGO.TX.Transaction> lookupData = new List<BGO.TX.Transaction>();
            var tx = (from x in Transaction select x).ToList();
            foreach (var t in tx)
            {
                lookupData.Add(new BGO.TX.Transaction()
                {
                    Person = new ContactDal().GetPersonByPersonId(t.PersonId),
                    Amount = t.Amount,
                    TransactionDate = t.CreatedOn,
                    TransactionTypeId = t.TransactionTypeId,
                    TransactionType = new LookupDal().GetAllTransactionType().Where(x => x.Id == t.TransactionTypeId).FirstOrDefault(),
                    Remarks = t.Remarks,
                    Id = t.Id

                });
            }

            return lookupData;
        }

        public List<BGO.TX.Transaction> GetTransaction(int personId)
        {
            List<BGO.TX.Transaction> lookupData = new List<BGO.TX.Transaction>();
            var tx = (from x in Transaction where x.PersonId == personId select x).ToList();
            foreach (var t in tx)
            {
                lookupData.Add(new BGO.TX.Transaction()
                {
                    Person = new ContactDal().GetPersonByPersonId(t.PersonId),
                    Amount = t.Amount,
                    TransactionDate = t.CreatedOn,
                    TransactionTypeId = t.TransactionTypeId,
                    TransactionType = new LookupDal().GetAllTransactionType().Where(x => x.Id == t.TransactionTypeId).FirstOrDefault(),
                    Remarks = t.Remarks,
                    Id = t.Id

                });
            }

            foreach (var item in Person.Where(x => x.GroupID.Value == personId))
            {
                var memberTransaxtions = (from x in Transaction where x.PersonId == item.Id select x).ToList();
                foreach (var t in memberTransaxtions)
                {
                    lookupData.Add(new BGO.TX.Transaction()
                    {
                        Person = new ContactDal().GetPersonByPersonId(t.PersonId),
                        Amount = t.Amount,
                        TransactionDate = t.CreatedOn,
                        TransactionTypeId = t.TransactionTypeId,
                        TransactionType = new LookupDal().GetAllTransactionType().Where(x => x.Id == t.TransactionTypeId).FirstOrDefault(),
                        Remarks = t.Remarks,
                        Id = t.Id

                    });
                }
            }

            return lookupData;
        }

        public void saveAttendance(int personId, DateTime date)
        {
            var t = (from x in Attendance where x.PersonId == personId && x.AttendanceDate == date && x.IsActive select x).FirstOrDefault();

            if (t != null)
            {
                return;
            }

            DB.Attendance newATT = new DB.Attendance()
            {
                PersonId = personId,
                AttendanceDate = date,
                CreatedOn = DateTime.Now,
                IsActive = true

            };
            Attendance.Add(newATT);
            SaveChanges();
        }

        public void saveTransaction(int personId, int transactionTypeId, decimal amount, DateTime? transactionDate, string remarks, bool IsGroupCharge = false)
        {
            var txList = (from x in Transaction where x.PersonId == personId && x.TransactionTypeId == transactionTypeId && x.IsActive.Value select x).ToList();
            //if (!IsGroupCharge)
            //{
            foreach (var tx in txList)
            {
                if (tx.CreatedOn.Date == transactionDate.Value.Date)
                {
                    return;
                }
            }
            //}

            DB.Transaction newTX = new DB.Transaction()
            {
                PersonId = personId,
                Amount = amount,
                CreatedOn = transactionDate.Value,
                TransactionTypeId = transactionTypeId,
                Remarks = remarks,
                IsActive = true
            };
            Transaction.Add(newTX);
            SaveChanges();
        }

        public List<BGO.TX.Transaction> GetTransaction(int txTypeId, DateTime txDate)
        {
            List<BGO.TX.Transaction> lookupData = new List<BGO.TX.Transaction>();
            var tx = (from x in Transaction where x.TransactionTypeId == txTypeId && x.IsActive.Value select x).ToList();
            foreach (var t in tx)
            {
                if (t.CreatedOn.Date != txDate.Date)
                    continue;
                lookupData.Add(new BGO.TX.Transaction()
                {
                    Person = new ContactDal().GetPersonByPersonId(t.PersonId),
                    Amount = t.Amount,
                    TransactionDate = t.CreatedOn,
                    TransactionTypeId = t.TransactionTypeId,
                    TransactionType = new LookupDal().GetAllTransactionType().Where(x => t.Id == t.TransactionTypeId).FirstOrDefault(),
                });
            }

            return lookupData;
        }

        public List<BGO.Member.Member> GetAttendanceByDate(DateTime txDate)
        {
            List<BGO.Member.Member> lookupData = new List<BGO.Member.Member>();
            var tx = (from x in Attendance where x.IsActive select x).OrderBy(n => n.Person.Fname).ToList();
            foreach (var t in tx)
            {
                if (t.AttendanceDate.Date != txDate.Date)
                    continue;
                lookupData.Add(new BGO.Member.Member()
                {
                    Person = new ContactDal().GetPersonByPersonId(t.PersonId),
                    Id = t.PersonId
                });
            }

            return lookupData;
        }

        public void MapAttendance(int personId, DateTime attendanceDate)
        {
            var atx = (from x in Attendance where x.PersonId == personId select x).ToList();

            foreach (var at in atx)
            {
                if (at.AttendanceDate.Date != attendanceDate.Date)
                    continue;

                at.IsActive = false;
                Attendance.Attach(at);
                Entry(at).State = EntityState.Deleted;
                SaveChanges();

            }


            var tx = (from x in Transaction where x.TransactionTypeId == 2 && x.PersonId == personId select x).ToList();

            foreach (var t in tx)
            {
                if (t.CreatedOn.Date != attendanceDate.Date)
                    continue;

                t.IsActive = false;
                Transaction.Attach(t);
                Entry(t).State = EntityState.Deleted;
                SaveChanges();

            }
        }

        public decimal GetAccountBalance(int personId)
        {
            decimal val = 0m;

            var group = (from x in Person where x.GroupID.Value == personId && x.IsActive select x).ToList();

            foreach (var member in group)
            {
                var tx = (from x in Transaction where x.PersonId == member.Id select x).ToList();
                val = val + Math.Round(tx.Sum(x => x.Amount), 2);
            }

            var mytx = (from x in Transaction where x.PersonId == personId select x).ToList();
            val = val + Math.Round(mytx.Sum(x => x.Amount), 2);
            return val;
        }

        public void DeleteTransaction(int txId)
        {
            var tx = (from x in Transaction where x.Id == txId select x).FirstOrDefault();
            Transaction.Remove(tx);
            SaveChanges();
        }

        public List<BGO.Member.Attendance> GetAttendanceByPersonId(int id)
        {
            List<BGO.Member.Attendance> lookupData = new List<BGO.Member.Attendance>();
            var tx = (from x in Attendance where x.PersonId == id select x).OrderByDescending(n => n.CreatedOn).ToList();
            foreach (var t in tx)
            {
                lookupData.Add(new BGO.Member.Attendance()
                {
                    Person = new ContactDal().GetPersonByPersonId(t.PersonId),
                    Id = t.Id,
                    AttendanceDate = t.AttendanceDate,
                    CreatedOn = t.CreatedOn,
                    IsActive = t.IsActive
                });
            }

            var group = (from x in Person where x.GroupID.Value == id && x.IsActive select x).ToList();
            foreach (var member in group)
            {
                var memberAttendance = (from x in Attendance where x.PersonId == member.Id select x).OrderByDescending(n => n.CreatedOn).ToList();
                foreach (var t in memberAttendance)
                {
                    lookupData.Add(new BGO.Member.Attendance()
                    {
                        Person = new ContactDal().GetPersonByPersonId(t.PersonId),
                        Id = t.Id,
                        AttendanceDate = t.AttendanceDate,
                        CreatedOn = t.CreatedOn,
                        IsActive = t.IsActive
                    });
                }
            }

            return lookupData;
        }
    }

    public class MxDal : bgDBContainer
    {


        public List<BGO.Mailout.MailoutQueue> GetAllMailouts(int? personId)
        {
            List<BGO.Mailout.MailoutQueue> q = new List<BGO.Mailout.MailoutQueue>();



            if (personId.HasValue)
            {
                var data = (from x in MailoutQueue.Where(x => x.PersonId == personId.Value) select x).ToList();
             

                foreach (var d in data)
                {
                    var mxtype = (from y in MailoutType where y.Id == d.MailoutTypeId select y).FirstOrDefault();
                    MxType t = new MxType()
                    {
                        Description = mxtype.Description,
                        Id = mxtype.Id,
                        Name = mxtype.Name,
                        Subject = mxtype.Subject
                    };

                    BGO.Mailout.MailoutQueue x = new BGO.Mailout.MailoutQueue()
                    {
                        CreatedOn = d.CreatedOn,
                        Email = d.EmailAddress,
                        HTML = d.HtmlBody,
                        Id = d.Id,
                        MailoutTypeId = d.MailoutTypeId,
                        Status = d.Status,
                        UpdatedOn = d.UpdateOn,
                        Person = new ContactDal().GetPersonByPersonId(d.PersonId),
                        Type = t,
                        Subject = t.Subject
                    };

                    q.Add(x);
                }
            }
            return q;
        }

        public void CheckMailoutParameters(Dictionary<string, string> inputParameters, int mailoutTypeId)
        {
            var requiredParameters = (from x in MailoutTypeParameter where x.MailoutTypeId == mailoutTypeId select x).ToList();

            if (requiredParameters.Count != inputParameters.Count())
            {
                throw new Exception($"Numbers of parameters are not matching with mailouttypeId: {mailoutTypeId}");
            }

        }

        public BGO.Mailout.MailoutQueue PushNotification(BGO.Contact.Person p, Dictionary<string, string> inputParameters, int mailoutTypeId, string email, string html)
        {
            var requiredParameters = (from x in MailoutTypeParameter where x.MailoutTypeId == mailoutTypeId select x).ToList();

            if (requiredParameters.Count != inputParameters.Count())
            {
                throw new Exception($"Numbers of parameters are not matching with mailouttypeId: {mailoutTypeId}");
            }

            BGO.Mailout.MailoutQueue q = new BGO.Mailout.MailoutQueue()
            {
                Person = p,
                Email = email,
                MailoutTypeId = mailoutTypeId,
                CreatedOn = DateTime.Now,
                Status = 1,
                HTML = html
            };

            var px = (from x in Person where x.Id == p.Id select x).FirstOrDefault();
            var mt = (from x in MailoutType where x.Id == mailoutTypeId select x).FirstOrDefault();

            DB.MailoutQueue mq = new DB.MailoutQueue()
            {
                Person = px,
                CreatedOn = DateTime.Now,
                HtmlBody = html,
                MailoutType = mt,
                EmailAddress = email,
                MailoutTypeId = mailoutTypeId,
                Status = 1,
                PersonId = px.Id
            };

            mq.MailoutQueueParameterValue = ParameterHandling(inputParameters, mailoutTypeId);
            MailoutQueue.Add(mq);
            SaveChanges();

            return q;

        }

        private ICollection<MailoutQueueParameterValue> ParameterHandling(Dictionary<string, string> inputParameters, int mailoutTypeId)
        {
            List<MailoutQueueParameterValue> mqpv = new List<MailoutQueueParameterValue>();
            var requiredParameters = (from x in MailoutTypeParameter where x.MailoutTypeId == mailoutTypeId select x).ToList();

            foreach (var param in inputParameters)
            {
                mqpv.Add(new MailoutQueueParameterValue()
                {
                    MailoutTypeParameter = requiredParameters.Where(x => x.MailoutParameter.Name.ToLower() == param.Key.ToLower()).FirstOrDefault(),
                    Value = param.Value,

                });
            }

            return mqpv;
        }

        public BGO.Mailout.MailoutQueue GetMailoutQueueById(int id)
        {
            var data = (from x in MailoutQueue where x.Id == id select x).FirstOrDefault();
            BGO.Mailout.MailoutQueue q = new BGO.Mailout.MailoutQueue()
            {
                Id = data.Id,
                CreatedOn = data.CreatedOn,
                Email = data.EmailAddress,
                HTML = data.HtmlBody,
                MailoutTypeId = data.MailoutTypeId,
                Status = data.Status,
                UpdatedOn = data.UpdateOn,
                Person = new ContactDal().GetPersonByPersonId(data.PersonId),
                Type = new MxType()
                {
                    Description = data.MailoutType.Description,
                    Id = data.MailoutType.Id,
                    Name = data.MailoutType.Name
                }
            };
            return q;
        }


        public void TrackMailout(BGO.Mailout.MailoutQueue q, string ipaddress)
        {

            var data = (from x in MailoutQueue where x.Id == q.Id select x).FirstOrDefault();
            MailoutTracker tracker = new MailoutTracker()
            {
                MailoutQueueId = q.Id,
                IPAddress = ipaddress,
                OpenedOn = DateTime.Now,
                MailoutQueue = data
            };

            MailoutTracker.Add(tracker);
            SaveChanges();
        }

        public void UpdateNotification(int mailoutQueueId)
        {
            var p = (from x in MailoutQueue where x.Id == mailoutQueueId select x).FirstOrDefault();
            p.Status = 0;
            MailoutQueue.Attach(p);
            Entry(p).State = EntityState.Modified;
            SaveChanges();
        }


    }
}
