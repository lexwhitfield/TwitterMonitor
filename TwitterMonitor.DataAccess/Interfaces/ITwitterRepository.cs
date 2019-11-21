using System.Threading.Tasks;
using TwitterMonitor.DataModels.SqlServer.Models;

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
    }
}
