//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HRM_Management_System.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Attendence
    {
        public int id { get; set; }
        public Nullable<int> atten_emp_id { get; set; }
        public bool atten_status { get; set; }
        public Nullable<int> atten_leave_type_id { get; set; }
        public Nullable<System.DateTime> atten_date { get; set; }
        public string atten_reason { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Leave_type Leave_type { get; set; }
    }
}