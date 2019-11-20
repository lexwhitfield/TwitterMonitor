using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tweetinvi;
using TwitterMonitor.DataAccess;
using TwitterMonitor.DataModels;
using TwitterMonitor.Transform;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/tweetusers")]
    [Produces("application/json")]
    public class TwitterUsersController : ControllerBase
    {
        private readonly MemberDBContext _context;
        private readonly IDataRepository<TwitterUser> _twitterUserRepo;
        private readonly IDataRepository<TwitterStats> _twitterStatRepo;
        private readonly IDataRepository<TwitterFriends> _twitterFriendRepo;

        private const string consumerKey = "RDaLBut56yuG3lloMC2yjZIGv";
        private const string consumerSecret = "EsLEBBcQJppNFWbLfHx3Auh5F032OCpCEsQAVMQfckJeQsoDdw";
        private const string accessToken = "3135075776-KroVu87rgSFVfAWh3ALZkTlvCYlXuTIQHEAdbF9";
        private const string accessTokenSecret = "axHvrtykhYyRCGTA61GZMqg1gScIKznZjU3ROGdVEwAje";


        public TwitterUsersController(IDataRepository<TwitterUser> twitterUserRepo, IDataRepository<TwitterStats> twitterStatRepo, IDataRepository<TwitterFriends> twitterFriendRepo)
        {
            _context = new MemberDBContext();
            _twitterUserRepo = twitterUserRepo;
            _twitterStatRepo = twitterStatRepo;
            _twitterFriendRepo = twitterFriendRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTwitterUser([FromRoute] long id)
        {
            var twitterUser = await _context.TwitterUser.FindAsync(id);
            var twitterStats = await _context.TwitterStats.FindAsync(id);

            var viewModel = ModelTransformer.TwitterUserToTwitterUserViewModel(twitterUser, twitterStats);

            return Ok(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTwitterUser([FromBody] long id)
        {
            var twitterUser = await _context.TwitterUser.FindAsync(id);
            var twitterStats = await _context.TwitterStats.FindAsync(id);

            var details = UpdateTwitterDetails(twitterUser);

            if (details != (null, null))
            {
                twitterUser = details.Item1;
                _twitterUserRepo.Update(twitterUser);
                await _twitterUserRepo.SaveAsync(twitterUser);

                if (twitterStats == null)
                {
                    twitterStats = details.Item2;
                    _twitterStatRepo.Add(twitterStats);
                }
                else
                {
                    twitterStats = details.Item2;
                    _twitterStatRepo.Update(twitterStats);
                }

                await _twitterStatRepo.SaveAsync(twitterStats);
            }

            var viewModel = ModelTransformer.TwitterUserToTwitterUserViewModel(twitterUser, twitterStats);

            return Ok(viewModel);
        }

        private (TwitterUser, TwitterStats) UpdateTwitterDetails(TwitterUser twitterUser)
        {
            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            var user = Tweetinvi.User.GetUserFromId(twitterUser.Id);

            if (user == null)
                throw new Exception($"Twitter account could not be found with Id: {twitterUser.Id}, ScreenName: {twitterUser.ScreenName}");

            twitterUser.CreatedAt = user.CreatedAt;

            var twitterStats = new TwitterStats
            {
                Id = twitterUser.Id,
                FriendCount = user.FriendsCount,
                FollowerCount = user.FollowersCount
            };

            return (twitterUser, twitterStats);
        }
    }
}
