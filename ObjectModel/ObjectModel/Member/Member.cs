using BGO.Contact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BGO.Member
{
    public class Member
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public DateTime JoiningDate { get; set; }        
        public bool IsActive { get; set; }
        public int PersonTypeId { get; set; }  
        public Person Person { get; set; }
        public decimal AccountBalance { get; set; }
        public bool IsMembershipActive { get; set; } = true;
    }

    public class Attendance
    {
        public int Id { get; set; }        
        public System.DateTime AttendanceDate { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public bool IsActive { get; set; }
        public  Person Person { get; set; }
    }
}
