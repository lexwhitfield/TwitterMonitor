using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class AreaType
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Area> Areas { get; set; }
    }
}
