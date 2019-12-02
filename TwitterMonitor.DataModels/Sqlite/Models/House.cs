using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class House
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<HouseMember> Members { get; set; }
    }
}
