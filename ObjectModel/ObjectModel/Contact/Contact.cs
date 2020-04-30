using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGO.Contact
{
    public class PersonEmail
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public EmailType Type { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }

    public class PersonPhone
    {
        public int Id { get; set; }
        public string Value { get; set; }
        public PhoneType Type { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }

    public class PersonUpload
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public string Path { get; set; }
        public UploadType Type { get; set; }
        public System.DateTime CreatedOn { get; set; }
    }

    public class PersonAddress
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string State { get; set; }
        public string Landmark { get; set; }
        public int PersonId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public AddressType AddressType { get; set; }

        public string FullAddress
        {
            get
            {
                return $"Line1: {Line1} <br> Line2: {Line2} <br> City: {City} <br> State: {State} <br> Postcode: {Postcode}";
            }


        }

    }

    public class Person
    {
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Mname { get; set; }
        public string Lname { get; set; }
        public string IPaddress { get; set; }


        public DateTime DOB { get; set; }
        public short GenderId { get; set; }
        public bool IsActive { get; set; }
        public int SalutationId { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Name
        {
            get
            {
                return $"{Fname} {Mname} {Lname}";
            }
        }

        public string Sex
        {
            get
            {
                return GenderId == 1 ? "Male" : "Female";
            }
        }

        public List<PersonEmail> PersonEmail { get; set; }

        public List<PersonPhone> PersonPhone { get; set; }

        public List<PersonAddress> PersonAddress { get; set; }
        
        public int? GroupId { get; set; }

        public Person Group { get; set; }
    }

    public class EmailType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PhoneType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class AddressType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class UploadType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string EnglishName { get; set; }
        public bool IsActive { get; set; }
    }
}
