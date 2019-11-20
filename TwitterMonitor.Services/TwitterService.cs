using System;
using Tweetinvi;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.DataModels;

namespace TwitterMonitor.Services
{
    public class TwitterService
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

        public async void NewOrUpdatedTwitterDetails(string screenName, long? id, bool forceUpdate = false)
        {
            if (id.HasValue)
            {
                // twitter user already in db, but we don't always want to update the details
                if (forceUpdate)
                {
                    var twitterUser = await _twitterRepository.GetUser(id.Value);
                    var twitterStats = await _twitterRepository.GetStats(id.Value);

                    Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);
                    var user = User.GetUserFromScreenName(screenName);

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
            }
        }
    }
}
