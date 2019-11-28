using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Area
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OnsId { get; set; }
        public int AreaTypeId { get; set; }

        public AreaType AreaType { get; set; }
        public ICollection<ConstituencyArea> ConstituencyAreas { get; set; }
    }
}
