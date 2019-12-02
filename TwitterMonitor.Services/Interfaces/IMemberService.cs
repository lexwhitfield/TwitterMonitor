using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface IMemberService
    {
        Task<IEnumerable<MemberViewModel>> GetAll();
    }
}
