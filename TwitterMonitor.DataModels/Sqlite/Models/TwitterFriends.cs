namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class TwitterFriends
    {
        public long UserId { get; set; }
        public long FriendId { get; set; }

        public TwitterUser Friend { get; set; }
        public TwitterUser User { get; set; }
    }
}
