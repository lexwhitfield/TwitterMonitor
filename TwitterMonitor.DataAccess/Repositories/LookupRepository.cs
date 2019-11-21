using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.SqlServer;
using TwitterMonitor.DataModels.SqlServer.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class LookupRepository : ILookupRepository
    {
        private readonly MemberDBContext _context;

        public LookupRepository()
        {
            _context = new MemberDBContext();
        }

        public async Task<IEnumerable<Authority>> GetAuthorities()
        {
            var authorities = await _context.Authority
                .OrderBy(a => a.Name)
                .ToListAsync();

            return authorities;
        }

        public async Task<IEnumerable<Region>> GetRegions()
        {
            var regions = await _context.Region
                .OrderBy(r => r.Name)
                .ToListAsync();

            return regions;
        }

        public async Task<IEnumerable<Country>> GetCountries()
        {
            var countries = await _context.Country
                .ToListAsync();

            return countries;
        }
    }
}
