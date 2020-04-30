using BGO.Common;
using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGO.TX
{
    public class Transaction
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public TransactionType TransactionType { get; set; }
        public int TransactionTypeId { get; set; }
        public DateTime? TransactionDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; }
        public string Remarks { get; set; }


    }
}
