namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class TweetHashtag
    {
        public long Id { get; set; }
        public long TweetId { get; set; }
        public long HashtagId { get; set; }


        public Tweet Tweet { get; set; }
        public Hashtag Hashtag { get; set; }
    }
}
