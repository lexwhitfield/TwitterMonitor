using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels;
using TwitterMonitor.DataModels.SqlServer;
using TwitterMonitor.DataModels.SqlServer.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class TwitterRepository: ITwitterRepository
    {
        private readonly MemberSqlServerDBContext _context;

        public TwitterRepository()
        {
            _context = new MemberSqlServerDBContext();
        }

        public async Task<TwitterUser> GetUser(long id)
        {
            var twitterUser = await _context.TwitterUser.FindAsync(id);

            return twitterUser;
        }

        public async Task<TwitterStats> GetStats(long id)
        {
            var twitterStats = await _context.TwitterStats.FindAsync(id);

            return twitterStats;
        }

        public async Task<TwitterUser> AddUser(TwitterUser twitterUser)
        {
            _context.TwitterUser.Add(twitterUser);
            await _context.SaveChangesAsync();

            return twitterUser;
        }

        public async Task<TwitterStats> AddStats(TwitterStats twitterStats)
        {
            _context.TwitterStats.Add(twitterStats);
            await _context.SaveChangesAsync();

            return twitterStats;
        }
        
        public async Task<TwitterUser> UpdateUser(TwitterUser twitterUser)
        {
            _context.Entry(twitterUser).State = EntityState.Modified;
            _context.Set<TwitterUser>().Update(twitterUser);
            await _context.SaveChangesAsync();

            return twitterUser;
        }

        public async Task<TwitterStats> UpdateStats(TwitterStats twitterStats)
        {
            _context.Entry(twitterStats).State = EntityState.Modified;
            _context.Set<TwitterStats>().Update(twitterStats);
            await _context.SaveChangesAsync();

            return twitterStats;
        }
    }
}
