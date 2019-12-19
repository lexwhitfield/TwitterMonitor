using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.Services;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.ViewModels;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("api/tweetusers")]
    [Produces("application/json")]
    public class TwitterUsersController : ControllerBase
    {
        private readonly ITwitterService _twitterService;

        public TwitterUsersController()
        {
            _twitterService = new TwitterService();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTwitterUser([FromRoute] long id)
        {
            var user = await _twitterService.GetById(id);
            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTwitterUser([FromBody] long id)
        {
            var viewModel = await _twitterService.NewOrUpdatedTwitterDetails(string.Empty, id, true);
            return Ok(viewModel);
        }

        [HttpGet]
        [Route("tweets/{memberId}")]
        public IEnumerable<TweetViewModel> GetTweets(int memberId)
        {
            var tweets = _twitterService.GetTweets(memberId).Result;
            return tweets;
        }

        [HttpGet]
        [Route("getlatesttweets/{memberId}")]
        public bool GetLatestTweets(int memberId)
        {
            _twitterService.GetLatestTweets(memberId);
            return true;
        }
    }
}
