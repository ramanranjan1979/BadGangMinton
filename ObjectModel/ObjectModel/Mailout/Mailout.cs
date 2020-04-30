using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGO.Mailout
{
    public class MxType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HtmlBody { get; set; }
        public string Subject { get; set; }
    }

  

    public class MailoutQueue
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? UpdatedOn { get; set; }
        public string Email { get; set; }
        public Person Person { get; set; }
        public string HTML { get; set; }
        public int MailoutTypeId { get; set; }
        public int Status { get; set; }
        public string Subject { get; set; }
        public MxType Type { get; set; }
    }
}
