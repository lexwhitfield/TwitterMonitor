using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Country
    {
        public Country()
        {
            Region = new HashSet<Region>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Region> Region { get; set; }
    }
}
