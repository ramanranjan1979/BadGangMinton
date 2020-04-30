using BGO.Common;
using BGO.Contact;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BadGangMinton.View.Model
{
    public class TransactionListViewModel
    {
        public int TransactionId { get; set; }
        public TransactionType TransactionType { get; set; }
        public SelectList TransactionTypes { get; set; }
        public Person  Person { get; set; }
        public DateTime? TransactionDate { get; set; }        
        public decimal Amount { get; set; }
        public string Remarks { get; set; } = string.Empty;

    }

    public class TransactionViewModel
    {
        public string TransactionTypeId { get; set; }
        public SelectList TransactionTypes { get; set; }

        [Required(ErrorMessage = "Please select at least one member")]
        public string[] PersonId { get; set; }

        public SelectList People { get; set; }


        [Display(Name = "Date")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Transaction date is mandatory")]
        public Nullable<DateTime> TransactionDate { get; set; } = DateTime.Now;

        [Display(Name = "Amount")]        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Enter the transaction amount")]
        [RegularExpression(@"^\d+.?\d{0,2}$", ErrorMessage = "Invalid amount: maximum two decimal points")]
        [Range(1, 9999999999999999.99, ErrorMessage = "Invalid amount: max 18 digits")]
        public decimal Amount { get; set; }        

    }
}