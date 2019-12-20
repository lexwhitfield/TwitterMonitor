using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface ITwitterService
    {
        Task<TwitterUserViewModel> GetById(long id);
        Task<TwitterUserViewModel> NewOrUpdatedTwitterDetails(string screenName, long? id, bool forceUpdate = false);
        Task<List<TweetViewModel>> GetTweets(int memberId);
        void GetAllLatestTweets();
        void GetLatestTweets(long twitterId, long latestTweetId);
    }
}
