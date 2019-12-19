using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface ITwitterRepository
    {
        Task<TwitterUser> GetUser(long id);
        Task<TwitterStats> GetStats(long id);
        Task<TwitterUser> AddUser(TwitterUser twitterUser);
        Task<TwitterStats> AddStats(TwitterStats twitterStats);
        Task<TwitterUser> UpdateUser(TwitterUser twitterUser);
        Task<TwitterStats> UpdateStats(TwitterStats twitterStats);
        Task<List<Tweet>> GetTweets(int memberId);
        long GetTwitterIdForMember(int memberId);
        void AddTweet(Tweet newTweet);
        long AddHashtag(string text);
        void AddTweetHashtags(List<TweetHashtag> tweethashtags);
        long AddUserMention(UserMention userMention);
        void AddTweetUserMentions(List<TweetUserMention> tweetMentions);
        void AddTweetUrs(List<TweetUrl> tweetUrls);
    }
}
