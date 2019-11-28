﻿using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class ConstituencyRepository : IConstituencyRepository
    {
        private readonly MemberSqliteDBContext _context;

        public ConstituencyRepository()
        {
            _context = new MemberSqliteDBContext();
        }

        public async Task<IEnumerable<Constituency>> GetAll(string name, int? authorityId, int? regionId, int? countryId)
        {
            var constituencies = await _context.Constituencies
                .ToListAsync();

            if (!string.IsNullOrEmpty(name))
            {
                constituencies = constituencies
                    .Where(c => c.Name.Contains(name))
                    .ToList();
            }

            return constituencies.OrderBy(c => c.Name);
        }

        public async Task<Constituency> GetById(int id)
        {
            var constituency = await _context.Constituencies
                .FirstOrDefaultAsync(c => c.Id == id);

            return constituency;
        }

        public async Task<Constituency> Add(Constituency constituency)
        {
            _context.Set<Constituency>().Add(constituency);
            await _context.SaveChangesAsync();

            return constituency;
        }

        public async Task<Constituency> Update(Constituency constituency)
        {
            _context.Entry(constituency).State = EntityState.Modified;
            _context.Set<Constituency>().Update(constituency);
            await _context.SaveChangesAsync();

            return constituency;
        }

        public async Task<bool> Delete(int id)
        {
            var constituency = await _context.Constituencies.FindAsync(id);
            if (constituency == null)
            {
                return false;
            }

            _context.Constituencies.Remove(constituency);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
