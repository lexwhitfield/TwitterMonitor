using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels.ViewModels;

namespace TwitterMonitor.Services
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;

        public PartyService()
        {
            _partyRepository = new PartyRepository();
        }

        public async Task<IEnumerable<PartyViewModel>> GetAll()
        {
            var parties = await _partyRepository.GetAll();
            return parties.Select(ModelTransformer.PartyToPartyViewModel);
        }
    }
}
