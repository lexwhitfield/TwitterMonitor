using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels
{
    public partial class Member
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ConstituencyId { get; set; }
        public int PartyId { get; set; }
        public long? TwitterId { get; set; }
        public int StartYear { get; set; }
        public int? EndYear { get; set; }
        public bool WhipSuspended { get; set; }

        public virtual Constituency Constituency { get; set; }
        public virtual Party Party { get; set; }
        public virtual TwitterUser Twitter { get; set; }
    }
}
