//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB
{
    using System;
    using System.Collections.Generic;
    
    public partial class Member
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public bool IsActive { get; set; }
        public int PersonTypeId { get; set; }
    
        public virtual Person Person { get; set; }
        public virtual PersonType PersonType { get; set; }
    }
}