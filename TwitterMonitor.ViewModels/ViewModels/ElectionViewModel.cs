using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterMonitor.ViewModels.ViewModels
{
    public class ElectionViewModel
    {
        public int? Id { get; set; }
        public int? ElectionTypeId { get; set; }
        public string ElectionTypeName { get; set; }
        public string Name { get; set; }
        public DateTime? ElectionDate { get; set; }
    }
}
