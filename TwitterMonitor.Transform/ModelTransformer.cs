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
                AuthorityId = constituency.AuthorityId,
                AuthorityName = constituency.Authority != null ? constituency.Authority.Name : string.Empty,
                RegionName = constituency.Authority != null ? constituency.Authority.Region.Name : string.Empty,
                CountryName = constituency.Authority != null ? constituency.Authority.Region.Country.Name : string.Empty,
            };
        }

        public static Constituency ConstituencyViewModelToConstituency(ConstituencyViewModel constituencyViewModel, Constituency original = null)
        {
            var constituency = original ?? new Constituency();

            constituency.Name = constituencyViewModel.Name;
            constituency.AuthorityId = constituencyViewModel.AuthorityId;

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
            return new MemberViewModel
            {
                Id = member.Id,
                Name = member.Name,
                PartyId = member.PartyId,
                PartyName = member.Party != null ? member.Party.Name : string.Empty,
                ConstituencyId = member.ConstituencyId,
                ConstituencyName = member?.Constituency != null ? member.Constituency.Name : string.Empty,
                TwitterId = member.TwitterId,
                TwitterScreenName = (member.Twitter != null) ? member.Twitter.ScreenName : string.Empty,
                StartYear = member.StartYear,
                EndYear = member.EndYear,
                WhipSuspended = member.WhipSuspended
            };
        }

        public static Member MemberViewModelToMember(MemberViewModel memberViewModel, Member original = null)
        {
            var member = original ?? new Member();

            member.Name = memberViewModel.Name;
            member.PartyId = memberViewModel.PartyId;
            member.ConstituencyId = memberViewModel.ConstituencyId;
            member.StartYear = memberViewModel.StartYear ?? 0;
            member.EndYear = memberViewModel.EndYear;
            member.WhipSuspended = memberViewModel.WhipSuspended;

            return member;
        }

        public static AuthorityViewModel AuthorityToAuthorityViewModel(Authority authority)
        {
            return new AuthorityViewModel
            {
                Id = authority.Id,
                Name = authority.Name,
                RegionId = authority.RegionId,
                RegionName = authority.Region.Name,
                CountryName = authority.Region.Country.Name
            };
        }

        public static Authority AuthorityViewModelToAuthority(AuthorityViewModel authorityViewModel, Authority original = null)
        {
            var authority = original ?? new Authority();

            authority.Name = authorityViewModel.Name;
            authority.RegionId = authorityViewModel.RegionId;

            return authority;
        }

        public static KeyValueViewModel AuthorityToKeyValueViewModel(Authority authority)
        {
            return new KeyValueViewModel
            {
                Id = authority.Id,
                Name = authority.Name
            };
        }

        public static KeyValueViewModel RegionToKeyValueViewModel(Region region)
        {
            return new KeyValueViewModel
            {
                Id = region.Id,
                Name = region.Name
            };
        }

        public static KeyValueViewModel CountryToKeyValueViewModel(Country country)
        {
            return new KeyValueViewModel
            {
                Id = country.Id,
                Name = country.Name
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
    }
}
