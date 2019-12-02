using System;
using System.Linq;
using TwitterMonitor.DataModels.Sqlite.Models;
using TwitterMonitor.ViewModels;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Transform
{
    public class ModelTransformer
    {
        public static MemberViewModel MemberToMemberViewModel(Member member)
        {
            var house = member.Houses.FirstOrDefault().House;
            var party = member.Parties.FirstOrDefault().Party;
            var constituency = member.Constituencies.FirstOrDefault().Constituency;

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

                LatestHouseId = house.Id,
                LatestHouseName = house.Name,

                LatestConstituencyId = constituency.Id,
                LatestConstituencyName = constituency.Name,

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
    }
}
