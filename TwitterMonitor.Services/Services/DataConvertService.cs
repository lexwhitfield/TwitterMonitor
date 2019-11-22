using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;
using TwitterMonitor.DataModels.SqlServer;

namespace TwitterMonitor.Services.Services
{
    public class DataConvertService
    {
        // country
        public void ConvertCountriesSqlServerToSqlite()
        {
            using (var sqlServer = new MemberSqlServerDBContext())
            {
                using (var sqlite = new MemberSqliteDBContext())
                {
                    var countries = sqlServer.Country;

                    foreach (var country in countries)
                    {
                        var sqliteCountry = new Country
                        {
                            Id = country.Id,
                            Name = country.Name
                        };

                        sqlite.Country.Add(sqliteCountry);
                    }

                    sqlite.SaveChanges();
                }
            }
        }

        // region
        public void ConvertRegionsSqlServerToSqlite()
        {
            using (var sqlServer = new MemberSqlServerDBContext())
            {
                using (var sqlite = new MemberSqliteDBContext())
                {
                    var regions = sqlServer.Region;

                    foreach (var region in regions)
                    {
                        var sqliteRegion = new Region
                        {
                            Id = region.Id,
                            Name = region.Name,
                            CountryId = region.CountryId
                        };

                        sqlite.Region.Add(sqliteRegion);
                    }

                    sqlite.SaveChanges();
                }
            }
        }

        // authority
        public void ConvertAuthoritiesSqlServerToSqlite()
        {
            using (var sqlServer = new MemberSqlServerDBContext())
            {
                using (var sqlite = new MemberSqliteDBContext())
                {
                    var authorities = sqlServer.Authority;

                    foreach (var authority in authorities)
                    {
                        var sqliteAuthority = new Authority
                        {
                            Id = authority.Id,
                            Name = authority.Name,
                            RegionId = authority.RegionId
                        };

                        sqlite.Authority.Add(sqliteAuthority);
                    }

                    sqlite.SaveChanges();
                }
            }
        }

        // constituency
        public void ConvertConstituenciesSqlServerToSqlite()
        {
            using (var sqlServer = new MemberSqlServerDBContext())
            {
                using (var sqlite = new MemberSqliteDBContext())
                {
                    var constituencies = sqlServer.Constituency;

                    foreach (var constituency in constituencies)
                    {
                        var sqliteConstituency = new Constituency
                        {
                            Id = constituency.Id,
                            Name = constituency.Name,
                            AuthorityId = constituency.AuthorityId
                        };

                        sqlite.Constituency.Add(sqliteConstituency);
                    }

                    sqlite.SaveChanges();
                }
            }
        }

        // party
        public void ConvertPartiesSqlServerToSqlite()
        {
            using (var sqlServer = new MemberSqlServerDBContext())
            {
                using (var sqlite = new MemberSqliteDBContext())
                {
                    var parties = sqlServer.Party;

                    foreach (var party in parties)
                    {
                        var sqliteParty = new Party
                        {
                            Id = party.Id,
                            Name = party.Name
                        };

                        sqlite.Party.Add(sqliteParty);
                    }

                    sqlite.SaveChanges();
                }
            }
        }

        // event
        public void ConvertEventsSqlServerToSqlite()
        {
            using (var sqlServer = new MemberSqlServerDBContext())
            {
                using (var sqlite = new MemberSqliteDBContext())
                {
                    var events = sqlServer.Events;

                    foreach (var e in events)
                    {
                        var sqliteEvent = new Events
                        {
                            Id = e.Id,
                            Title = e.Title,
                            Body = e.Body,
                            Happened = e.Happened
                        };

                        sqlite.Events.Add(sqliteEvent);
                    }

                    sqlite.SaveChanges();
                }
            }
        }

        // twitterUser
        public void ConvertTwitterUsersSqlServerToSqlite()
        {
            using (var sqlServer = new MemberSqlServerDBContext())
            {
                using (var sqlite = new MemberSqliteDBContext())
                {
                    var users = sqlServer.TwitterUser;

                    foreach (var user in users)
                    {
                        var sqliteUser = new TwitterUser
                        {
                            Id = user.Id,
                            ScreenName = user.ScreenName,
                            CreatedAt = user.CreatedAt
                        };

                        sqlite.TwitterUser.Add(sqliteUser);
                    }

                    sqlite.SaveChanges();
                }
            }
        }

        public void ConvertMembersSqlServerToSqlite()
        {
            using (var sqlServer = new MemberSqlServerDBContext())
            {
                using (var sqlite = new MemberSqliteDBContext())
                {
                    sqlite.Member.RemoveRange(sqlite.Member);
                    sqlite.SaveChanges();

                    var members = sqlServer.Member;

                    foreach (var member in members)
                    {
                        var sqliteMember = new Member
                        {
                            Id = member.Id,
                            Name = member.Name,
                            ConstituencyId = member.ConstituencyId,
                            PartyId = member.PartyId,
                            TwitterId = (member.TwitterId != -1) ? member.TwitterId : null,
                            StartYear = member.StartYear,
                            EndYear = member.EndYear,
                            WhipSuspended = member.WhipSuspended
                        };

                        sqlite.Member.Add(sqliteMember);
                        sqlite.SaveChanges();
                    }                    
                }
            }
        }
    }
}
