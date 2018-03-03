using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HRM_Management_System.Models;

namespace HRM_Management_System.ViewModels
{
    public class ProfileViewModel
    {
        public Employee _employe { get; set; }
        public IEnumerable<Notice_Board> _notices { get; set; }
        public IEnumerable<Holiday> _holidays { get; set; }
        public IEnumerable<Award> _awards { get; set; }
    }
}