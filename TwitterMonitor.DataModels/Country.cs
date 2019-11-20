using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels
{
    public partial class Country
    {
        public Country()
        {
            Region = new HashSet<Region>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Region> Region { get; set; }
    }
}
