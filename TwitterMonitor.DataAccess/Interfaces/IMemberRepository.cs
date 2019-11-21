using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.SqlServer.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IMemberRepository
    {
        Task<Member> GetById(int id);
        Task<IEnumerable<Member>> GetAll(int? id, string name, int? partyId, string constituency, string twitterName);
        Task<bool> Delete(int id);
        Task<Member> Add(Member member);
        Task<Member> Update(int id, Member member);
    }
}
