using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterMonitor.ViewModels
{
    public class AreaViewModel
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int AreaTypeId { get; set; }
        public string AreaType { get; set; }
    }
}
