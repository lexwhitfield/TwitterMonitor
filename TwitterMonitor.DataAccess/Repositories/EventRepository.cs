using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.SqlServer;
using TwitterMonitor.DataModels.SqlServer.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class EventRepository : IEventRepository
    {
        private readonly MemberSqlServerDBContext _context;

        public EventRepository()
        {
            _context = new MemberSqlServerDBContext();
        }

        public async Task<IEnumerable<Events>> GetAll()
        {
            var events = await _context.Events.ToListAsync();
            return events;
        }

        public async Task<Events> GetById(int id)
        {
            var events = await _context.Events.FindAsync(id);
            return events;
        }

        public async Task<Events> Add(Events events)
        {
            _context.Set<Events>().Add(events);
            await _context.SaveChangesAsync();

            return events;
        }

        public async Task<Events> Update(Events events)
        {
            _context.Entry(events).State = EntityState.Modified;
            _context.Set<Events>().Update(events);
            await _context.SaveChangesAsync();

            return events;
        }

        public async Task<bool> Delete(int id)
        {
            var events = await _context.Events.FindAsync(id);
            if (events == null)
            {
                return false;
            }

            _context.Events.Remove(events);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
