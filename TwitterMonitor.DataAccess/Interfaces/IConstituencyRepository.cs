using System.Collections.Generic;
using System.Threading.Tasks;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IConstituencyRepository
    {
        Task<IEnumerable<Constituency>> GetAll(string name, int? authorityId, int? regionId, int? countryId);
        Task<Constituency> GetById(int id);
        Task<Constituency> Add(Constituency constituency);
        void AddMany(List<ConstituencyNew> constituencies);
        void AddMany(List<ConstituencyArea> constituencyAreas);
        Task<Constituency> Update(Constituency constituency);
        Task<bool> Delete(int id);
    }
}
