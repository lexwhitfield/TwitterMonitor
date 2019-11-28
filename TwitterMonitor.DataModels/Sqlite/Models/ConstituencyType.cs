using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class ConstituencyType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Constituency> Constituencies { get; set; }
    }
}
