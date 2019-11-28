using System;
using TwitterMonitor.DataModels.Sqlite.Models;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Transform
{
    public class ModelTransformer
    {
        public static ConstituencyViewModel ConstituencyToConstituencyViewModel(Constituency constituency)
        {
            return new ConstituencyViewModel
            {
                Id = constituency.Id,
                Name = constituency.Name,
                ConstituencyTypeId = constituency.ConstituencyTypeId,
                ConstituencyType = (constituency.ConstituencyTypeId.HasValue) ? constituency.ConstituencyType.Name : string.Empty
            };
        }

        public static Constituency ConstituencyViewModelToConstituency(ConstituencyViewModel constituencyViewModel, Constituency original = null)
        {
            var constituency = original ?? new Constituency();

            constituency.Name = constituencyViewModel.Name;
            constituency.ConstituencyTypeId = constituencyViewModel.ConstituencyTypeId;

            return constituency;
        }

        public static PartyViewModel PartyToPartyViewModel(Party party)
        {
            return new PartyViewModel
            {
                Id = party.Id,
                Name = party.Name
            };
        }

        public static Party PartyViewModelToParty(PartyViewModel partyViewModel, Party original = null)
        {
            var party = original ?? new Party();

            party.Name = partyViewModel.Name;

            return party;
        }

        public static MemberViewModel MemberToMemberViewModel(Member member)
        {
            //return new MemberViewModel
            //{
            //    Id = member.Id,
            //    TitleId = member.TitleId,
            //    Title = (member.TitleId.HasValue) ? member.Title.Name : string.Empty,
            //    Name = member.Name,
            //    PartyId = member.PartyId,
            //    PartyName = member.Party != null ? member.Party.Name : string.Empty,
            //    ConstituencyId = member.ConstituencyId,
            //    ConstituencyName = member?.Constituency != null ? member.Constituency.Name : string.Empty,
            //    TwitterId = member.TwitterId,
            //    TwitterScreenName = (member.Twitter != null) ? member.Twitter.ScreenName : string.Empty,
            //    StartYear = member.StartYear,
            //    EndYear = member.EndYear,
            //    WhipSuspended = member.WhipSuspended
            //};

            return null;
        }

        public static Member MemberViewModelToMember(MemberViewModel memberViewModel, Member original = null)
        {
            var member = original ?? new Member();

            //member.Name = memberViewModel.Name;
            //member.TitleId = memberViewModel.TitleId;
            //member.PartyId = memberViewModel.PartyId;
            //member.ConstituencyId = memberViewModel.ConstituencyId;
            //member.StartYear = memberViewModel.StartYear ?? 0;
            //member.EndYear = memberViewModel.EndYear;
            //member.WhipSuspended = memberViewModel.WhipSuspended;

            return member;
        }

        public static KeyValueViewModel AreaTypeToKeyValueViewModel(AreaType areaType)
        {
            return new KeyValueViewModel
            {
                Id = areaType.Id,
                Name = areaType.Name
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

        public static TwitterUserViewModel TwitterUserToTwitterUserViewModel(TwitterUser user, TwitterStats stats)
        {
            return new TwitterUserViewModel
            {
                Id = user.Id,
                ScreenName = user.ScreenName,
                CreatedAt = user.CreatedAt ?? DateTime.MinValue,
                MostRecentFollowerCount = stats?.FollowerCount ?? 0,
                MostRecentFriendCount = stats?.FriendCount ?? 0
            };
        }

        public static EventViewModel EventToEventViewModel(Events events)
        {
            return new EventViewModel
            {
                Id = events.Id,
                Title = events.Title,
                Body = events.Body,
                Happened = events.Happened
            };
        }

        public static Events EventViewModelToEvent(EventViewModel eventViewModel, Events original = null)
        {
            var events = original ?? new Events();

            events.Title = eventViewModel.Title;
            events.Body = eventViewModel.Body;
            events.Happened = eventViewModel.Happened;

            return events;
        }

        public static AreaViewModel AreaToAreaViewModel(Area area)
        {
            return new AreaViewModel
            {
                Id = area.Id,
                Name = area.Name,
                AreaTypeId = area.AreaTypeId,
                AreaType = area.AreaType.Name
            };
        }

        public static Area AreaViewModelToArea(AreaViewModel areaViewModel, Area original)
        {
            var area = original ?? new Area();

            area.Name = areaViewModel.Name;
            area.AreaTypeId = areaViewModel.AreaTypeId;

            return area;
        }
    }
}
