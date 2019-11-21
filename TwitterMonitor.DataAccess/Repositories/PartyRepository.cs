using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class PartyRepository : IPartyRepository
    {
        private readonly MemberDBContext _context;

        public PartyRepository()
        {
            _context = new MemberDBContext();
        }

        public async Task<Party> GetById(int id)
        {
            var party = await _context.Party.FindAsync(id);
            return party;
        }

        public async Task<IEnumerable<Party>> GetAll()
        {
            var parties = await _context.Party.OrderBy(p => p.Name).ToListAsync();
            return parties;
        }

        public async Task<Party> Add(Party party)
        {
            _context.Set<Party>().Add(party);
            await _context.SaveChangesAsync();

            return party;
        }

        public async Task<Party> Update(Party party)
        {
            _context.Entry(party).State = EntityState.Modified;
            _context.Set<Party>().Update(party);
            await _context.SaveChangesAsync();

            return party;
        }

        public async Task<bool> Delete(int id)
        {
            var party = await _context.Party.FindAsync(id);
            if (party == null)
            {
                return false;
            }

            _context.Party.Remove(party);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
