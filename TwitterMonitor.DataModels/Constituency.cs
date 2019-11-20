using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels
{
    public partial class Constituency
    {
        public Constituency()
        {
            Member = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AuthorityId { get; set; }

        public virtual Authority Authority { get; set; }
        public virtual ICollection<Member> Member { get; set; }
    }
}
