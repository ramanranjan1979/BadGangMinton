using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGO.Common
{
    
    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string EnglishName { get; set; }
        public bool IsActive { get; set; }
    }

    public class GenderType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class EmailType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class JobTitle
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class Occupation
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public partial class LogType
    {
        public int Id { get; set; }
        public string Name { get; set; }   
    }

    public class PersonType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Salutation
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }

    public class AddressType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class ContactNumberType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public partial class SocialProfileType
    {
        public int Id { get; set; }
        public string Name { get; set; }     
    }

    public partial class MailoutType
    {
        public string HtmlBody { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
    }

    public partial class TransactionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Multiplier { get; set; }
        public string Desc { get; set; }
    }


    public partial class UploadType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class Log
    {
        public int Id { get; set; }        
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public LogType LogType { get; set; }
        public Person Person { get; set; }
    }
}
