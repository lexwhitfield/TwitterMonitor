using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class CommitteeType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Committee> Committees { get; set; }
    }
}
