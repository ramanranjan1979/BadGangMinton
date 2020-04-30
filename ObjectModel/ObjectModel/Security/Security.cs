using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGO.Security
{
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
        public Person Person { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ExpiredOn { get; set; }
    }


    public class UserLogin
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreatedOn { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public Nullable<DateTime> LockedOn { get; set; }
        public bool IsActive { get; set; }
        public bool IsLock { get; set; }
        public Person Person { get; set; }

    }
}
