using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.DataModels.Sqlite.Models;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services
{
    public class TwitterService : ITwitterService
    {
        private const string consumerKey = "RDaLBut56yuG3lloMC2yjZIGv";
        private const string consumerSecret = "EsLEBBcQJppNFWbLfHx3Auh5F032OCpCEsQAVMQfckJeQsoDdw";
        private const string accessToken = "3135075776-KroVu87rgSFVfAWh3ALZkTlvCYlXuTIQHEAdbF9";
        private const string accessTokenSecret = "axHvrtykhYyRCGTA61GZMqg1gScIKznZjU3ROGdVEwAje";

        private readonly ITwitterRepository _twitterRepository;

        public TwitterService()
        {
            _twitterRepository = new TwitterRepository();
        }

        public async Task<TwitterUserViewModel> GetById(long id)
        {
            var twitterUser = await _twitterRepository.GetUser(id);
            var twitterStats = await _twitterRepository.GetStats(id);

            return ModelTransformer.TwitterUserToTwitterUserViewModel(twitterUser, twitterStats);
        }

        public async Task<TwitterUserViewModel> NewOrUpdatedTwitterDetails(string screenName, long? id, bool forceUpdate = false)
        {
            if (id.HasValue)
            {
                // twitter user already in db, but we don't always want to update the details
                if (forceUpdate)
                {
                    var twitterUser = await _twitterRepository.GetUser(id.Value);
                    var twitterStats = await _twitterRepository.GetStats(id.Value);

                    Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
                    var user = User.GetUserFromId(id.Value);

                    if (user == null)
                    {
                        // throw an error
                    }

                    twitterUser.ScreenName = user.ScreenName;
                    twitterUser.CreatedAt = user.CreatedAt;

                    twitterStats.FriendCount = user.FriendsCount;
                    twitterStats.FollowerCount = user.FollowersCount;

                    await _twitterRepository.UpdateUser(twitterUser);
                    await _twitterRepository.UpdateStats(twitterStats);

                    return ModelTransformer.TwitterUserToTwitterUserViewModel(twitterUser, twitterStats);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
                var user = User.GetUserFromScreenName(screenName);

                if (user == null)
                {
                    // throw an error
                }

                var twitterUser = new TwitterUser
                {
                    Id = user.Id,
                    ScreenName = user.ScreenName,
                    CreatedAt = user.CreatedAt
                };

                var twitterStats = new TwitterStats
                {
                    Id = user.Id,
                    FriendCount = user.FriendsCount,
                    FollowerCount = user.FollowersCount
                };

                await _twitterRepository.AddUser(twitterUser);
                await _twitterRepository.AddStats(twitterStats);

                return ModelTransformer.TwitterUserToTwitterUserViewModel(twitterUser, twitterStats);
            }
        }

        public async Task<List<TweetViewModel>> GetTweets(int memberId)
        {
            var tweets = await _twitterRepository.GetTweets(memberId);
            return tweets.Select(ModelTransformer.TweetToTweetViewModel).ToList();
        }

        public void GetLatestTweets(int memberId)
        {
            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            var twitterId = _twitterRepository.GetTwitterIdForMember(memberId);

            var latestTweets = Timeline.GetUserTimeline(twitterId, 200);

            foreach (var tweet in latestTweets)
            {
                DataModels.Sqlite.Models.Tweet newTweet = new DataModels.Sqlite.Models.Tweet
                {
                    Id = tweet.Id,
                    TwitterUserId = tweet.CreatedBy.Id,
                    FullText = tweet.FullText,
                    CreatedAt = tweet.CreatedAt,
                    InReplyToScreenName = tweet.InReplyToScreenName,
                    InReplyToStatusId = tweet.InReplyToStatusId,
                    InReplyToUserId = tweet.InReplyToUserId,
                    QuotedStatusId = tweet.QuotedStatusId
                };

                _twitterRepository.AddTweet(newTweet);

                // hashtags
                List<TweetHashtag> tweethashtags = new List<TweetHashtag>();

                foreach (var hashtag in tweet.Hashtags)
                {
                    long hashtagId = _twitterRepository.AddHashtag(hashtag.Text);

                    tweethashtags.Add(new TweetHashtag
                    {
                        TweetId = tweet.Id,
                        HashtagId = hashtagId
                    });
                }

                if (tweethashtags.Count > 0)
                    _twitterRepository.AddTweetHashtags(tweethashtags);

                // mentions
                List<TweetUserMention> tweetMentions = new List<TweetUserMention>();

                foreach (var mention in tweet.UserMentions)
                {
                    long userId = _twitterRepository.AddUserMention(new UserMention { Id = mention.Id ?? -1, ScreenName = mention.ScreenName });

                    tweetMentions.Add(new TweetUserMention
                    {
                        TweetId = tweet.Id,
                        UserMentionId = userId
                    });
                }

                if (tweetMentions.Count > 0)
                    _twitterRepository.AddTweetUserMentions(tweetMentions);

                // urls
                List<TweetUrl> tweetUrls = new List<TweetUrl>();

                foreach (var url in tweet.Urls)
                {
                    tweetUrls.Add(new TweetUrl
                    {
                        TweetId = tweet.Id,
                        Url = url.ExpandedURL
                    });
                }

                if (tweetUrls.Count > 0)
                    _twitterRepository.AddTweetUrs(tweetUrls);
            }
        }
    }
}
