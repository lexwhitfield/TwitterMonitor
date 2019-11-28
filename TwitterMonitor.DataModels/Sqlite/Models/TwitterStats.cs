namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class TwitterStats
    {
        public long Id { get; set; }
        public int FollowerCount { get; set; }
        public int FriendCount { get; set; }

        public TwitterUser TwitterUser { get; set; }
    }
}
