using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class ConstituencyArea
    {
        public long Id { get; set; }
        public int ConstituencyId { get; set; }
        public int AreaId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }


        public ConstituencyNew Constituency { get; set; }
        public Area Area { get; set; }
    }
}
