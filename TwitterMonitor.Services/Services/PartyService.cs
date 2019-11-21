using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services
{
    public class PartyService: IPartyService
    {
        private readonly IPartyRepository _partyRepository;

        public PartyService()
        {
            _partyRepository = new PartyRepository();
        }

        public async Task<PartyViewModel> GetById(int id)
        {
            var party = await _partyRepository.GetById(id);
            return ModelTransformer.PartyToPartyViewModel(party);
        }

        public async Task<IEnumerable<PartyViewModel>> GetAll()
        {
            var parties = await _partyRepository.GetAll();
            return parties.Select(ModelTransformer.PartyToPartyViewModel);
        }

        public async Task<PartyViewModel> Add(PartyViewModel partyViewModel)
        {
            var party = await _partyRepository.Add(ModelTransformer.PartyViewModelToParty(partyViewModel));
            return ModelTransformer.PartyToPartyViewModel(party);
        }

        public async Task<PartyViewModel> Update(PartyViewModel partyViewModel)
        {
            var original = await _partyRepository.GetById(partyViewModel.Id.Value);
            var party = await _partyRepository.Update(ModelTransformer.PartyViewModelToParty(partyViewModel, original));
            return ModelTransformer.PartyToPartyViewModel(party);
        }

        public async Task<bool> Delete(int id)
        {
            var success = await _partyRepository.Delete(id);
            return success;
        }
    }
}
