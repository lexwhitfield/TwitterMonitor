using System.Threading.Tasks;
using WebApp.DataModel;

namespace WebApp.Data
{
    public class DataRepository<T> : IDataRepository<T> where T : class
    {
        private readonly MemberDBContext _context;

        public DataRepository()
        {
            _context = new MemberDBContext();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<T> SaveAsync(T entity)
        {
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
