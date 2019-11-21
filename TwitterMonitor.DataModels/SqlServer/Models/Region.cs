using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.SqlServer.Models
{
    public partial class Region
    {
        public Region()
        {
            Authority = new HashSet<Authority>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Authority> Authority { get; set; }
    }
}
