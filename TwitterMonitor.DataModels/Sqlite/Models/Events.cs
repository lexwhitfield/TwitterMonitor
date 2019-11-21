using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Events
    {
        public int Id { get; set; }
        public DateTime Happened { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
    }
}
