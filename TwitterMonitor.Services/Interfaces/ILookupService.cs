using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Interfaces
{
    public interface ILookupService
    {
        Task<IEnumerable<KeyValueViewModel>> GetAuthorities();
        Task<IEnumerable<KeyValueViewModel>> GetRegions();
        Task<IEnumerable<KeyValueViewModel>> GetCountries();
    }
}
