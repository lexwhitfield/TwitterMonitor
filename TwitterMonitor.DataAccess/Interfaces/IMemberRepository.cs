using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> GetById(int id);
        Task<IEnumerable<Member>> GetAll();
        Task<bool> Delete(int id);
        Task<Member> Add(Member member);
        Task<Member> Update(int id, Member member);
    }
}
