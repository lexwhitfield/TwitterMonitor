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

    }
}
