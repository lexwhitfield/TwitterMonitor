using System;
using System.Collections.Generic;

namespace WebApp.DataModel
{
    public partial class Authority
    {
        public Authority()
        {
            Constituency = new HashSet<Constituency>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int RegionId { get; set; }

        public virtual Region Region { get; set; }
        public virtual ICollection<Constituency> Constituency { get; set; }
    }
}
