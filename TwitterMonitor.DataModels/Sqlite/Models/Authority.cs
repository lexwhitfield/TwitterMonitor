using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Authority
    {
        public Authority()
        {
            Constituency = new HashSet<Constituency>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public Region Region { get; set; }
        public ICollection<Constituency> Constituency { get; set; }
    }
}
