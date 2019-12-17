using System;
using System.Collections.Generic;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Tweet
    {
        public long Id { get; set; }
        public long TwitterUserId { get; set; }
        public string FullText { get; set; }
        public DateTime CreatedAt { get; set; }
        public string InReplyToScreenName { get; set; }
        public long? InReplyToStatusId { get; set; }
        public long? InReplyToUserId { get; set; }
        public bool IsRetweet { get; set; }
        public long? QuotedStatusId { get; set; }


        public TwitterUser TwitterUser { get; set; }
        public ICollection<TweetHashtag> Hashtags { get; set; }
        public ICollection<TweetUserMention> UserMentions { get; set; }
        public ICollection<TweetUrl> Urls { get; set; }
    }
}
