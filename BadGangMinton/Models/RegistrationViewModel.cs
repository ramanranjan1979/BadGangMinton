using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.View.Model
{

    public class VerifictionViewModel : RegistrationViewModel
    {
        public string VerificationCode { get; set; }
        public int PersonId { get; set; }
    }


    public class RegistrationViewModel
    {

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email Address")]
        [StringLength(50, MinimumLength = 7,ErrorMessage ="Length of email address must be 7 to 50 characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your email address")]
        [Remote("DoesEmailExist", "Base", HttpMethod = "POST", ErrorMessage = "Email already exists so please use another email address.")]
        public string PrimaryEmail { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "user name can only contain letters")]
        [Remote("DoesUserNameExist", "Base", HttpMethod = "POST", ErrorMessage = "User name already exists so please choose a different user name")]
        [MinLength(5, ErrorMessage = "User name should be 5 characters minimum")]
        [MaxLength(20, ErrorMessage = "User name cannot be more than 20 characters")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be 6 or more characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your password")]
        public string Password { get; set; } = "duy$w$52";

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Sorry the Password does not match")]
        public string ConfirmPassword { get; set; } = "duy$w$52";


        [Display(Name = "First Name")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="First name is mandatory")]
        [StringLength(50, MinimumLength = 3,ErrorMessage ="Length of First name should be 3 to 50 characters")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First name can only be alphabets(a to z)")]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]                
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Middle name can only be alphabets(a to z)")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="Last name is mandatory")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Length of last name should be 3 to 50 characters")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last name can only be alphabets(a to z)")]
        public string LastName { get; set; }
                      

        [Required(AllowEmptyStrings = false, ErrorMessage = "Date of birth is mandatory")]        
        public Nullable<DateTime> DateOfBirth { get; set; }


        [Display(Name = "Contact Number")]
        [DataType(DataType.PhoneNumber)]               
        [Required(AllowEmptyStrings =false,ErrorMessage ="Phone number is mandatory")]
        [StringLength(15, MinimumLength = 10,ErrorMessage ="Please check contact number")]
        public string PhoneNumber { get; set; }

        [DataType(DataType.Text)]
        public string AddressLine1 { get; set; }

        [DataType(DataType.Text)]
        public string AddressLine2 { get; set; }

        [DataType(DataType.Text)]
        public string City { get; set; }

        [DataType(DataType.Text)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "State or county name can only be alphabets(a to z)")]
        public string State { get; set; }

        [DataType(DataType.PostalCode)]
        public string PostCode { get; set; }

        public string Gender { get; set; }
        public string CountryId { get; set; }
        public string SalutuionId { get; set; }

        public SelectList CountrySelectList { get; set; }
        public SelectList SalutationSelectList { get; set; }
        public SelectList GenderSelectList { get; set; }
        
    }
}