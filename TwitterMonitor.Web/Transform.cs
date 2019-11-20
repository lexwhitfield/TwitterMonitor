using System;
using WebApp.DataModel;
using WebApp.ViewModels;

namespace WebApp
{
    public class Transform
    {
        internal static ConstituencyViewModel ConstituencyToConstituencyViewModel(Constituency constituency)
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

        internal static Constituency ConstituencyViewModelToConstituency(ConstituencyViewModel constituencyViewModel, Constituency original = null)
        {
            var constituency = original ?? new Constituency();

            constituency.Name = constituencyViewModel.Name;
            constituency.AuthorityId = constituencyViewModel.AuthorityId;

            return constituency;
        }

        internal static PartyViewModel PartyToPartyViewModel(Party party)
        {
            return new PartyViewModel
            {
                Id = party.Id,
                Name = party.Name
            };
        }

        internal static Party PartyViewModelToParty(PartyViewModel partyViewModel, Party original = null)
        {
            var party = original ?? new Party();

            party.Name = partyViewModel.Name;

            return party;
        }

        internal static MemberViewModel MemberToMemberViewModel(Member member)
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
                TwitterScreenName = (member.TwitterId.HasValue) ? member.Twitter.ScreenName : string.Empty,
                StartYear = member.StartYear,
                EndYear = member.EndYear,
                WhipSuspended = member.WhipSuspended
            };
        }

        internal static Member MemberViewModelToMember(MemberViewModel memberViewModel, Member original = null)
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

        internal static AuthorityViewModel AuthorityToAuthorityViewModel(Authority authority)
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

        internal static Authority AuthorityViewModelToAuthority(AuthorityViewModel authorityViewModel, Authority original = null)
        {
            var authority = original ?? new Authority();

            authority.Name = authorityViewModel.Name;
            authority.RegionId = authorityViewModel.RegionId;

            return authority;
        }

        internal static KeyValueViewModel AuthorityToKeyValueViewModel(Authority authority)
        {
            return new KeyValueViewModel
            {
                Id = authority.Id,
                Name = authority.Name
            };
        }

        internal static KeyValueViewModel RegionToKeyValueViewModel(Region region)
        {
            return new KeyValueViewModel
            {
                Id = region.Id,
                Name = region.Name
            };
        }

        internal static KeyValueViewModel CountryToKeyValueViewModel(Country country)
        {
            return new KeyValueViewModel
            {
                Id = country.Id,
                Name = country.Name
            };
        }

        internal static TwitterUserViewModel TwitterUserToTwitterUserViewModel(TwitterUser user, TwitterStats stats)
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
    }
}
