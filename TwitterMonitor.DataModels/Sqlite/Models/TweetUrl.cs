namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class TweetUrl
    {
        public long Id { get; set; }
        public long TweetId { get; set; }
        public string Url { get; set; }


        public Tweet Tweet { get; set; }
    }
}
