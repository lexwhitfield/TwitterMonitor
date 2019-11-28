using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberViewModel>> GetAllMembers(int? id, string name, int? partyId, string constituency, string twitterName);
        Task<MemberViewModel> GetMemberById(int id);
        Task<MemberViewModel> UpdateMember(MemberViewModel memberViewModel);
        Task<MemberViewModel> AddMember(MemberViewModel memberViewModel);
        Task<bool> DeleteMember(int id);
    }
}
