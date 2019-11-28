using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class ParliamentaryRank
    {
        public int Id { get; set; }
        public string Name { get; set; }


        public ICollection<ParliamentaryPost> ParliamentaryPosts { get; set; }
    }
}
