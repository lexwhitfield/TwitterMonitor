using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberViewModel>> GetAll(string name, int? partyId, string constituencyName, int? electionId, int? constituencyId);
        Task<IEnumerable<MemberViewModel>> GetAllWithTwitter(string name, int? partyId, string constituencyName);
        Task<MemberViewModel> GetById(int memberId);
    }
}
