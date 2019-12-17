using System;
using System.Linq;
using TwitterMonitor.DataModels.Sqlite.Models;
using TwitterMonitor.ViewModels;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Transform
{
    public class ModelTransformer
    {
        public static KeyValueViewModel AreaToKeyValueViewModel(Area area)
        {
            return new KeyValueViewModel
            {
                Id = area.Id,
                Name = area.Name
            };
        }

        public static MemberViewModel MemberToMemberViewModel(Member member)
        {
            var house = member.Houses.OrderBy(hm => hm.StartDate).LastOrDefault().House;
            var party = member.Parties.OrderBy(pm => pm.StartDate).LastOrDefault().Party;
            var constituencyMember = member.Constituencies.Count > 0 ? member.Constituencies.OrderBy(c => c.StartDate).LastOrDefault() : null;

            return new MemberViewModel
            {
                Id = member.Id,
                DodsId = member.DodsId,
                PimsId = member.PimsId,
                ClerksId = member.ClerksId,

                TitleId = member.TitleId,
                TitleName = (member.Title != null) ? member.Title.Name : string.Empty,
                Forename = member.Forename,
                Surname = member.Surname,

                GenderId = member.GenderId,
                GenderName = member.Gender.Name,

                DateOfBirth = member.DateOfBirth,
                DateOfDeath = member.DateOfDeath,

                TwitterUserName = member.TwitterUser != null ? member.TwitterUser.ScreenName : string.Empty,
                TwitterId = member.TwitterUserId,

                LatestHouseId = house.Id,
                LatestHouseName = house.Name,

                LatestConstituencyId = constituencyMember.Constituency != null ? constituencyMember.Constituency.Id : (int?)null,
                LatestConstituencyName = constituencyMember.Constituency != null ? constituencyMember.Constituency.Name : string.Empty,

                LatestElectionId = constituencyMember.Election != null ? constituencyMember.Election.Id : (int?)null,
                LatestElectionName = constituencyMember.Election != null ? constituencyMember.Election.Name : string.Empty,

                LatestPartyId = party.Id,
                LatestPartyName = party.Name,
                LatestPartyBgColour = !string.IsNullOrEmpty(party.Colour) ? party.Colour : "FFFFFF",
                LatestPartyTextColour = !string.IsNullOrEmpty(party.TextColour) ? party.TextColour : "333333",

                NumberOfGovernmentPosts = member.GovernmentPosts.Count,
                NumberOfOppositionPosts = member.OppositionPosts.Count,
                NumberOfParliamentaryPosts = member.ParliamentaryPosts.Count,
                NumberOfCommittees = member.Committees.Count
            };
        }

        public static ConstituencyViewModel ConstituencyToConstituencyViewModel(Constituency constituency)
        {
            var latestMember = constituency.ConstituencyMembers.Count > 0 ? constituency.ConstituencyMembers.Last().Member : null;
            var latestParty = latestMember != null ? latestMember.Parties.Last().Party : null;

            return new ConstituencyViewModel
            {
                Id = constituency.Id,
                Name = constituency.Name,
                ConstituencyTypeId = constituency.ConstituencyTypeId,
                ConstituencyTypeName = (constituency.ConstituencyTypeId.HasValue) ? constituency.ConstituencyType.Name : "Other",
                OldDodsId = constituency.OldDodsId,
                OldDisId = constituency.OldDisId,
                ClerksConstituencyId = constituency.ClerksConstituencyId,
                GisId = constituency.GisId,
                PcaCode = constituency.PcaCode,
                PconName = constituency.PconName,
                OsName = constituency.OsName,
                StartDate = constituency.StartDate,
                EndDate = constituency.EndDate,
                OnsCode = constituency.OnsCode,
                SchoolSubsidyBand = constituency.SchoolsSubsidyBand,
                Areas = String.Join(", ", constituency.ConstituencyAreas
                    .OrderByDescending(ca => ca.Area.AreaTypeId)
                    .Select(ca => ca.Area.Name)),
                CurrentMemberId = latestMember != null ? latestMember.Id : -1,
                CurrentMemberName = latestMember != null ? latestMember.Forename + " " + latestMember.Surname : string.Empty,
                CurrentPartyId = latestParty != null ? latestParty.Id : -1,
                CurrentPartyName = latestParty != null ? latestParty.Name : string.Empty
            };
        }

        public static KeyValueViewModel ConstituencyTypeToKeyValueViewModel(ConstituencyType constituencyType)
        {
            return new KeyValueViewModel
            {
                Id = constituencyType.Id,
                Name = constituencyType.Name
            };
        }

        public static PartyViewModel PartyToPartyViewModel(Party party)
        {
            return new PartyViewModel
            {
                Id = party.Id,
                Name = party.Name,
                Abbr = party.Abbr,
                Initials = party.Initials,
                BgColour = party.Colour,
                TextColour = party.TextColour,
                IsCommons = party.IsCommons,
                IsLords = party.IsLords,
                OldDisId = party.OldDisId,
                HoLMainParty = party.HoLMainParty,
                HoLOrder = party.HoLOrder,
                HoLIsSpiritualSide = party.HoLIsSpiritualSide,
                TotalMemberCount = party.Members.Count,
                ActiveMemberCount = party.Members.Where(m => !m.EndDate.HasValue).Count()
            };
        }

        public static ElectionViewModel ElectionToElectionViewModel(Election election)
        {
            return new ElectionViewModel
            {
                Id = election.Id,
                Name = election.Name,
                ElectionTypeId = election.ElectionTypeId,
                ElectionTypeName = election.ElectionType.Name,
                ElectionDate = election.ElectionDate,
                MembersElected = election.Members.Count
            };
        }

        public static KeyValueViewModel ElectionTypeToKeyValueViewModel(ElectionType electionType)
        {
            return new KeyValueViewModel
            {
                Id = electionType.Id,
                Name = electionType.Name
            };
        }

        public static Events EventViewModelToEvent(EventViewModel eventViewModel, Events original = null)
        {
            throw new NotImplementedException();
        }

        public static EventViewModel EventToEventViewModel(Events events)
        {
            throw new NotImplementedException();
        }

        public static TwitterUserViewModel TwitterUserToTwitterUserViewModel(TwitterUser twitterUser, TwitterStats twitterStats)
        {
            throw new NotImplementedException();
        }

        public static TweetViewModel TweetToTweetViewModel(Tweet tweet)
        {
            return new TweetViewModel
            {
                Id = tweet.Id,
                FullText = tweet.FullText,
                CreatedAt = tweet.CreatedAt,
                IsRetweet = tweet.IsRetweet,
                HashtagCount = tweet.Hashtags.Count,
                Hashtags = string.Join(", ", tweet.Hashtags.Select(h => h.Hashtag.Tag)),
                UserMentionCount = tweet.UserMentions.Count,
                UserMentions = string.Join(", ", tweet.UserMentions.Select(um => um.UserMention.ScreenName)),
                UrlCount = tweet.Urls.Count
            };
        }
    }
}
