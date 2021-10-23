using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BGO.Common;

namespace BadGangMinton.View.Model
{
 
    public class PersonViewModel 
    {
        public int Id { get; set; }

        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "First name is mandatory")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Length of First name should be 3 to 20 characters")]
        [DataType(DataType.Text)]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        [DataType(DataType.Text)]
        public string MiddleName { get; set; }


        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last name is mandatory")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Length of First name should be 3 to 20 characters")]
        [DataType(DataType.Text)]
        public string LastName { get; set; }


        [Display(Name = "Date of birth")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of birth is mandatory")]
        public DateTime? DOB { get; set; }


        public DateTime DateCreated { get; set; } = DateTime.Now;

        #region dropdowns
        public string GenderTypeId { get; set; }
        public SelectList Gender { get; set; }

        public string SalutationTypeId { get; set; }
        public SelectList Salutations { get; set; }

        public string PersonTypeId { get; set; }
        public SelectList PersonTypes { get; set; }
        #endregion

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Email Address")]
        [Remote("DoesEmailExist", "Base", HttpMethod = "POST", ErrorMessage = "Email address already exists. Please use a different email address.")]
        public string PrimaryEmail { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Contact number is mandatory")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Please check contact number")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "ContactNumber")]
        public string PrimaryContactNumber { get; set; }

        public List<EmailAddress> PersonEmail { get; set; }
        public List<Address> PersonAddress { get; set; }
        public List<Contact> PersonContactNumber { get; set; }

        public int? GroupId { get; set; }

    }

    public class EmailAddress
    {
        public int Id { get; set; }
        public EmailType Type { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 5,ErrorMessage ="Email address should be 5 to 50 characters long")]
        [Display(Name = "Email Address")]
        public string Value { get; set; }
        public DateTime DateCreated { get; set; } = DateTime.Now;
    }

    public class Address
    {
        public int Id { get; set; }
        public AddressType Type { get; set; }
        public int CountryId { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Address Line 1")]
        public string Line1 { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [StringLength(50, MinimumLength = 10)]
        [Display(Name = "Address Line 2")]
        public string Line2 { get; set; }

        [Required]
        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "City")]
        public string City { get; set; }


        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "State")]
        [StringLength(50, MinimumLength = 5)]
        public string State { get; set; }

        [Required]
        [DataType(DataType.PostalCode)]
        [StringLength(8, MinimumLength = 4)]
        [Display(Name = "Post Code")]
        public string PostCode { get; set; }

        [DataType(DataType.Text)]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "Landmark")]
        public string Landmark { get; set; }
                
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }

    public class Contact
    {

        public int Id { get; set; }
        public ContactNumberType Type { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 5)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Number")]        
        public string Value { get; set; }        
        public DateTime CreatedOn { get; set; } = DateTime.Now;
    }

    public class GenderType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class MemberViewModel
    {
        public int PersonId { get; set; } 

        [Display(Name = "Date of joining")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of joining is mandatory")]
        public DateTime? DOJ { get; set; }

        public List<BGO.Contact.Person> PotentialMember { get; set; }
    }

   


    public class PhotoViewModel
    {
        public int PersonId { get; set; }
        public HttpPostedFileBase FileToUpload { get; set; }
    }



    public class Attendance
    {

        public int Id { get; set; }
       

        [Display(Name = "Start Date")]
        [Required]        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime StartDate { get; set; } = DateTime.Now.AddYears(-2);

        [Display(Name = "End Date")]
        [Required]        
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime EndDate { get; set; } = DateTime.Now;

        public DateTime? AttDate { get; set; } =  DateTime.Now;

        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? ModifiedOn { get; set; }

    }

    public class AttendanceViewModel : Attendance
    {
        public string PersonId { get; set; }
        public SelectList Members { get; set; }        
    }


    public class AttachPersonViewModel
    {
        public string MainPersonIdId { get; set; }
        public SelectList People { get; set; }
    }

    public class TxFilterViewModel
    {
        public string PlayerPersonId { get; set; }
        public SelectList Players { get; set; }

        public string TxTypeId { get; set; }
        public SelectList TxTypes { get; set; }
    }

    public class LogFilterViewModel
    {
        public string PersonId { get; set; }
        public SelectList People { get; set; }

        public string LogTypeId { get; set; }
        public SelectList LogTypes { get; set; }
    }
}