namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class TweetUserMention
    {
        public long Id { get; set; }
        public long TweetId { get; set; }
        public long UserMentionId { get; set; }


        public Tweet Tweet { get; set; }
        public UserMention UserMention { get; set; }
    }
}
