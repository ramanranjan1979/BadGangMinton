using BadGangMinton.View.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BadGangMinton.View.Model
{

    public class Login
    {
        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your username")]
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter you password")]
        public string Password { get; set; }

        public string NavTo { get; set; }

    }

    public class NewPeronLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int PersonId { get; set; }
        public SelectList people { get; set; }

        public int roleId { get; set; }
        public SelectList roles { get; set; }
    }


    public class SystemLog
    {
        public int Id { get; set; }
        public LogType Type { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public BGO.Contact.Person Person { get; set; }
    }

    public class SupportViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your name")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Message cannot be blank")]
        [DataType(DataType.Text)]
        [MaxLength(250, ErrorMessage = "Message length cannot be more than 250 characters")]
        public string Message { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter you email")]
        public string EmailAddress { get; set; }

        public bool isMemnber { get; set; } = true;

        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the subject")]
        public string Subject { get; set; }
    }

    public class LogType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ForgotPassword
    {
        [DataType(DataType.EmailAddress)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your email address")]
        public string EmailAddress { get; set; }

        [DataType(DataType.Text)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your username")]
        [MaxLength(15, ErrorMessage = "Username cannot be more than 15 characters")]
        [MinLength(5, ErrorMessage = "Username cannot be less than 5 characters")]
        public string UserName { get; set; }
    }

    public class ChangePassword
    {
        public int loginId { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be 6 or more characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be 6 or more characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your new password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be 6 or more characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your new password")]
        [System.ComponentModel.DataAnnotations.Compare("NewPassword", ErrorMessage = "New password and confirm password is not matching")]
        public string ConfirmPassword { get; set; }        

    }


    public class SecurityType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SecurityTypeCode
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public SecurityType SecurityType { get; set; }
        public BGO.Contact.Person Person { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ExpiredOn { get; set; }
    }

    public class ResetPassword
    {
        public BGO.Contact.Person Person { get; set; }

        [DataType(DataType.Text)]
        [MinLength(5, ErrorMessage = "Minimum 5 characters are allowed in security code")]
        [MaxLength(10, ErrorMessage = "Maximum 10 characters are allowed in security code")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the security code")]
        public string SecurityCode { get; set; }



        [DataType(DataType.Password)]
        [MaxLength(10, ErrorMessage = "Password cannot be more than 10 characters")]
        [MinLength(5, ErrorMessage = "Password cannot be less than 5 characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter you password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "New password and confirm password is not matching")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please confirm your password")]
        public string ConfirmPassword { get; set; }
    }

    public class ResetPasswordViewModel
    {
        public int PersonId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string EmailAddress { get; set; }

        [DataType(DataType.Text)]
        [MinLength(5, ErrorMessage = "Security code is not valid")]
        [MaxLength(10, ErrorMessage = "Security code is not valid")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter your security code")]
        public string SecurityCode { get; set; }

        [DataType(DataType.Text)]
        [MinLength(5, ErrorMessage = "Security code is not valid")]
        [MaxLength(10, ErrorMessage = "Security code is not valid")]
        [System.ComponentModel.DataAnnotations.Compare("SecurityCode", ErrorMessage = "Sorry the security code does not match")]
        public string ConfirmSecurityCode { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Password must be 6 or more characters")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter your password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "Sorry the Password does not match")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm your password")]
        public string ConfirmPassword { get; set; }
    }

    public class UserManagementViewModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public Nullable<DateTime> LockedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsLock { get; set; }
        public BGO.Contact.Person Person { get; set; }

    }
}