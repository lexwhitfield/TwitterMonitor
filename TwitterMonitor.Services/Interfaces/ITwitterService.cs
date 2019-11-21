using System.Threading.Tasks;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface ITwitterService
    {
        Task<TwitterUserViewModel> GetById(long id);
        Task<TwitterUserViewModel> NewOrUpdatedTwitterDetails(string screenName, long? id, bool forceUpdate = false);
    }
}
