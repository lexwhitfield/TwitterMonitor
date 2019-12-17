using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class UserMention
    {
        public long Id { get; set; }
        public string ScreenName { get; set; }


        public ICollection<TweetUserMention> Tweets { get; set; }
    }
}
