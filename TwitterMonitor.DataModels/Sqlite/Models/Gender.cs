using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Gender
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<Member> Members { get; set; }
    }
}
