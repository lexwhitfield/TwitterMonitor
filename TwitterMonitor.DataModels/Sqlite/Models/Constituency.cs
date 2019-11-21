using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Constituency
    {
        public Constituency()
        {
            Member = new HashSet<Member>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? AuthorityId { get; set; }

        public Authority Authority { get; set; }
        public ICollection<Member> Member { get; set; }
    }
}
