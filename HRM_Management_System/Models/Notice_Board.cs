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
    
    public partial class Notice_Board
    {
        public int id { get; set; }
        public string notice_title { get; set; }
        public string notice_content { get; set; }
        public bool notice_status { get; set; }
        public Nullable<int> notice_depart_id { get; set; }
    
        public virtual Departament Departament { get; set; }
    }
}
