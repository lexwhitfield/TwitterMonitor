using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class TwitterRepository : ITwitterRepository
    {
        private readonly MemberSqliteDBContext _context;

        public TwitterRepository()
        {
            _context = new MemberSqliteDBContext();
        }

        public async Task<TwitterUser> GetUser(long id)
        {
            var twitterUser = await _context.TwitterUsers.FindAsync(id);

            return twitterUser;
        }

        public async Task<TwitterStats> GetStats(long id)
        {
            var twitterStats = await _context.TwitterStats.FindAsync(id);

            return twitterStats;
        }

        public async Task<TwitterUser> AddUser(TwitterUser twitterUser)
        {
            _context.TwitterUsers.Add(twitterUser);
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

        public async Task<List<Tweet>> GetTweets(int memberId)
        {
            var tweets = _context.Tweets
                .Include(t => t.Hashtags)
                .ThenInclude(th => th.Hashtag)
                .Include(t => t.UserMentions)
                .ThenInclude(um => um.UserMention)
                .Include(t => t.Urls)
                .Include(t => t.TwitterUser)
                .ThenInclude(tu => tu.Member)
                .Where(t => t.TwitterUser.Member.Id == memberId);

            return  await tweets.ToListAsync();
        }

        public long GetTwitterIdForMember(int memberId)
        {
            return _context.Members.Find(memberId).TwitterUserId ?? -1;
        }

        public void AddTweet(Tweet newTweet)
        {
            _context.Tweets.Add(newTweet);
            _context.SaveChanges();
        }

        public long AddHashtag(string text)
        {
            var hashtag = _context.Hashtags.FirstOrDefault(h => h.Tag.Equals(text, System.StringComparison.InvariantCultureIgnoreCase));

            if (hashtag == null)
            {
                var newHashtag = new Hashtag
                {
                    Tag = text
                };

                _context.Hashtags.Add(newHashtag);
                _context.SaveChanges();

                return newHashtag.Id.Value;
            }
            else
            {
                return hashtag.Id.Value;
            }
        }

        public void AddTweetHashtags(List<TweetHashtag> tweethashtags)
        {
            _context.TweetHashtags.AddRange(tweethashtags);
            _context.SaveChanges();
        }

        public long AddUserMention(UserMention userMention)
        {
            var user = _context.UserMentions.FirstOrDefault(um => um.Id == userMention.Id);

            if (user == null)
            {
                _context.UserMentions.Add(userMention);
                _context.SaveChanges();

                return userMention.Id;
            }
            else
            {
                return user.Id;
            }
        }

        public void AddTweetUserMentions(List<TweetUserMention> tweetMentions)
        {
            _context.TweetUserMentions.AddRange(tweetMentions);
            _context.SaveChanges();
        }

        public void AddTweetUrs(List<TweetUrl> tweetUrls)
        {
            _context.TweetUrls.AddRange(tweetUrls);
            _context.SaveChanges();
        }
    }
}
