using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Hashtag
    {
        public long? Id { get; set; }
        public string Tag { get; set; }


        public ICollection<TweetHashtag> Tweets { get; set; }
    }
}
