using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tweetinvi;
using WebApp.Data;
using WebApp.DataModel;
using WebApp.ViewModels;

namespace WebApp.Services
{
    public class MemberService
    {
        private readonly MemberDBContext _context;
        private readonly IDataRepository<Member> _memberRepo;
        private readonly IDataRepository<TwitterUser> _twitterUserRepo;
        private readonly IDataRepository<TwitterStats> _twitterStatsRepo;

        private const string consumerKey = "RDaLBut56yuG3lloMC2yjZIGv";
        private const string consumerSecret = "EsLEBBcQJppNFWbLfHx3Auh5F032OCpCEsQAVMQfckJeQsoDdw";
        private const string accessToken = "3135075776-KroVu87rgSFVfAWh3ALZkTlvCYlXuTIQHEAdbF9";
        private const string accessTokenSecret = "axHvrtykhYyRCGTA61GZMqg1gScIKznZjU3ROGdVEwAje";

        public MemberService(IDataRepository<Member> repo, IDataRepository<TwitterUser> _tweet, IDataRepository<TwitterStats> _stats)
        {
            _context = new MemberDBContext();
            _memberRepo = repo;
            _twitterUserRepo = _tweet;
            _twitterStatsRepo = _stats;
        }

        public IEnumerable<MemberViewModel> GetAllMembers(int? id, string name, int? partyId, string constituency, string twitterName)
        {
            try
            {
                var members = _context.Member
                    .Include(m => m.Constituency)
                    .Include(m => m.Party)
                    .Include(m => m.Twitter)
                    .OrderBy(m => m.Name).ToList();

                if (id.HasValue)
                    members = members.Where(m => m.Id == id.Value).ToList();

                if (!string.IsNullOrEmpty(name))
                    members = members.Where(m => m.Name.Contains(name, StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (partyId.HasValue)
                    members = members.Where(m => m.PartyId == partyId.Value).ToList();

                if (!string.IsNullOrEmpty(constituency))
                    members = members.Where(m => m.Constituency.Name.Contains(constituency, StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (!string.IsNullOrEmpty(twitterName))
                    members = members.Where(m => m.TwitterId.HasValue)
                        .Where(m => m.Twitter.ScreenName.Contains(twitterName, StringComparison.InvariantCultureIgnoreCase)).ToList();

                return members.Select(Transform.MemberToMemberViewModel);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<MemberViewModel> GetMemberById(int id)
        {
            var member = await _context.Member
                .Include(m => m.Constituency)
                .Include(m => m.Party)
                .Include(m => m.Twitter)
                .FirstOrDefaultAsync(m => m.Id == id);
            return Transform.MemberToMemberViewModel(member);
        }

        public async Task<MemberViewModel> UpdateMember(MemberViewModel memberViewModel)
        {
            var original = _context.Member.Include(m => m.Twitter).FirstOrDefault(m => m.Id == memberViewModel.Id);

            // is twitter screen name different?
            if ((!original.TwitterId.HasValue && !string.IsNullOrEmpty(memberViewModel.TwitterScreenName)) || original.Twitter.ScreenName != memberViewModel.TwitterScreenName)
            {
                var twitterDetails = GetNewTwitterDetails(memberViewModel.TwitterScreenName);

                _twitterUserRepo.Add(twitterDetails.Item1);
                await _twitterUserRepo.SaveAsync(twitterDetails.Item1);

                _twitterStatsRepo.Add(twitterDetails.Item2);
                await _twitterStatsRepo.SaveAsync(twitterDetails.Item2);

                original.TwitterId = twitterDetails.Item1.Id;
            }

            var member = Transform.MemberViewModelToMember(memberViewModel, original);

            _context.Entry(member).State = EntityState.Modified;
            _memberRepo.Update(member);
            await _memberRepo.SaveAsync(member);

            return Transform.MemberToMemberViewModel(member);
        }

        public async Task<MemberViewModel> AddMember(MemberViewModel memberViewModel)
        {
            var member = Transform.MemberViewModelToMember(memberViewModel);

            var twitterDetails = (!string.IsNullOrEmpty(memberViewModel.TwitterScreenName)) ? GetNewTwitterDetails(memberViewModel.TwitterScreenName) : (null, null);

            if (twitterDetails != (null, null))
            {
                _twitterUserRepo.Add(twitterDetails.Item1);
                await _twitterUserRepo.SaveAsync(twitterDetails.Item1);

                _twitterStatsRepo.Add(twitterDetails.Item2);
                await _twitterStatsRepo.SaveAsync(twitterDetails.Item2);

                member.TwitterId = twitterDetails.Item1.Id;
            }

            _memberRepo.Add(member);
            await _memberRepo.SaveAsync(member);

            member = _context.Member.Include(m => m.Party).Include(m => m.Constituency).FirstOrDefault(m => m.Id == member.Id);

            return Transform.MemberToMemberViewModel(member);
        }

        public async Task<MemberViewModel> DeleteMember(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _memberRepo.Delete(member);
            await _memberRepo.SaveAsync(member);

            return Transform.MemberToMemberViewModel(member);
        }

        private (TwitterUser, TwitterStats) GetNewTwitterDetails(string screenName)
        {       
            //already exists in DB?

            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            var user = User.GetUserFromScreenName(screenName);

            if (user == null)
                return (null, null);

            var tUser = new TwitterUser
            {
                Id = user.Id,
                ScreenName = user.ScreenName,
                CreatedAt = user.CreatedAt
            };

            var tStats = new TwitterStats
            {
                Id = user.Id,
                FriendCount = user.FriendsCount,
                FollowerCount = user.FollowersCount
            };

            return (tUser, tStats);
        }

        private (TwitterUser, TwitterStats) UpdateTwitterDetails(TwitterUser twitterUser)
        {
            Auth.SetUserCredentials(consumerKey, consumerSecret, accessToken, accessTokenSecret);

            var user = User.GetUserFromId(twitterUser.Id);

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
