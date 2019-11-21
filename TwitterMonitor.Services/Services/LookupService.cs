using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services.Services
{
    public class LookupService : ILookupService
    {
        private readonly ILookupRepository _lookupRepository;

        public LookupService()
        {
            _lookupRepository = new LookupRepository();
        }

        public async Task<IEnumerable<KeyValueViewModel>> GetAuthorities()
        {
            var authorities = await _lookupRepository.GetAuthorities();
            return authorities.Select(ModelTransformer.AuthorityToKeyValueViewModel);
        }

        public async Task<IEnumerable<KeyValueViewModel>> GetRegions()
        {
            var regions = await _lookupRepository.GetRegions();
            return regions.Select(ModelTransformer.RegionToKeyValueViewModel);
        }

        public async Task<IEnumerable<KeyValueViewModel>> GetCountries()
        {
            var countries = await _lookupRepository.GetCountries();
            return countries.Select(ModelTransformer.CountryToKeyValueViewModel);
        }
    }
}
