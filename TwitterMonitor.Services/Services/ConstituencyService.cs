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
    public class ConstituencyService : IConstituencyService
    {
        private readonly IConstituencyRepository _constituencyRepository;

        public ConstituencyService()
        {
            _constituencyRepository = new ConstituencyRepository();
        }

        public async Task<IEnumerable<ConstituencyViewModel>> GetAll(string name, int? authorityId, int? regionId, int? countryId)
        {
            var constituencies = await _constituencyRepository.GetAll(name, authorityId, regionId, countryId);
            return constituencies.Select(ModelTransformer.ConstituencyToConstituencyViewModel);
        }

        public async Task<ConstituencyViewModel> GetById(int id)
        {
            var constituency = await _constituencyRepository.GetById(id);
            return ModelTransformer.ConstituencyToConstituencyViewModel(constituency);
        }
        public async Task<ConstituencyViewModel> Add(ConstituencyViewModel constituencyViewModel)
        {
            var constituency = await _constituencyRepository.Add(ModelTransformer.ConstituencyViewModelToConstituency(constituencyViewModel));
            return ModelTransformer.ConstituencyToConstituencyViewModel(constituency);
        }

        public async Task<ConstituencyViewModel> Update(ConstituencyViewModel constituencyViewModel)
        {
            var original = await _constituencyRepository.GetById(constituencyViewModel.Id.Value);
            var constituency = await _constituencyRepository.Update(ModelTransformer.ConstituencyViewModelToConstituency(constituencyViewModel, original));
            return ModelTransformer.ConstituencyToConstituencyViewModel(constituency);
        }

        public async Task<bool> Delete(int id)
        {
            var success = await _constituencyRepository.Delete(id);
            return success;
        }
    }
}
