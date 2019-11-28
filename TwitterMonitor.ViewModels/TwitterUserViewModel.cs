using System;

namespace TwitterMonitor.ViewModels
{
    public class TwitterUserViewModel
    {
        public long Id { get; set; }
        public string ScreenName { get; set; }
        public DateTime CreatedAt { get; set; }
        public int MostRecentFriendCount { get; set; }
        public int MostRecentFollowerCount { get; set; }
    }
}
