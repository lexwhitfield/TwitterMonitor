using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataAccess.Repositories;
using TwitterMonitor.Services.Interfaces;
using TwitterMonitor.Transform;
using TwitterMonitor.ViewModels;

namespace TwitterMonitor.Services
{
    public class PartyService : IPartyService
    {
        private readonly IPartyRepository _partyRepository;

        public PartyService()
        {
            _partyRepository = new PartyRepository();
        }
    }
}
