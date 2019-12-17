using System;

namespace TwitterMonitor.ViewModels
{
    public class TweetViewModel
    {
        public long Id { get; set; }
        public string FullText { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsRetweet { get; set; }

        public int HashtagCount { get; set; }
        public string Hashtags { get; set; }
        public int UserMentionCount { get; set; }
        public string UserMentions { get; set; }
        public int UrlCount { get; set; }
    }
}
