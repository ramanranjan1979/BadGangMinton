using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.View.Model
{
    public class MailoutViewModel
    {
    }

    public class MailoutViewModelCompose
    {

        public int PersonTypeId { get; set; }
        public SelectList PersonTypeList { get; set; }

        [Display(Name = "Sub Category")]
        [Required]
        public int Grade { get; set; }
        public SelectList GradeList { get; set; }

        [Display(Name = "Target")]
        [Required]
        [DataType(DataType.Text)]
        public string Target { get; set; }

        [Display(Name = "PersonListId")]
        [Required]
        [DataType(DataType.Text)]
        public string PersonListId { get; set; }


        [Display(Name = "Subject")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Subject { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "From Email Address")]
        public string From { get; set; }

        [Required]
        [StringLength(500, MinimumLength = 5)]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }

    public class MailoutCompose
    {

        [Required(ErrorMessage = "Please select at least one person")]
        public string[] PersonId { get; set; }
        public SelectList People { get; set; }


        [Display(Name = "Subject")]
        [Required(AllowEmptyStrings =false,ErrorMessage ="subject is mandatory")]
        [StringLength(50, MinimumLength = 3)]
        [DataType(DataType.Text)]
        public string Subject { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="Sender is mandatory")]
        [DataType(DataType.EmailAddress)]
        [StringLength(50, MinimumLength = 5)]
        [Display(Name = "From Email Address")]
        public string From { get; set; }

        [Required(AllowEmptyStrings =false,ErrorMessage ="message is mandatory")]
        [StringLength(500, MinimumLength = 5,ErrorMessage ="message should be 5 to 500 max characters in length")]
        [Display(Name = "Message")]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}