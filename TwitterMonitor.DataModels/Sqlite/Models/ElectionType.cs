using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class ElectionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Election> Elections { get; set; }
    }
}
