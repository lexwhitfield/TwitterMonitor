using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels
{
    public partial class Events
    {
        public int Id { get; set; }
        public DateTime Happened { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
