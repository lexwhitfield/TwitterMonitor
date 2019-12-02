using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterMonitor.ViewModels.ViewModels
{
    public class DepartmentViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public bool? Minister { get; set; }
        public bool? Secretary { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
