using System.Collections.Generic;
using TwitterMonitor.DataAccess.Interfaces;
using TwitterMonitor.DataModels.Sqlite;
using TwitterMonitor.DataModels.Sqlite.Models;

namespace TwitterMonitor.DataAccess.Repositories
{
    public class DataImportRepository : IDataImportRepository
    {
        private readonly MemberSqliteDBContext _context;

        public DataImportRepository()
        {
            _context = new MemberSqliteDBContext();
        }

        public async void AddAreas(List<Area> areas)
        {
            await _context.AddRangeAsync(areas);
            await _context.SaveChangesAsync();
        }

        //public async void AddConstituencies(List<ConstituencyNew> constituencies)
        //{
        //    _context.ConstituencyNew.AddRange(constituencies);
        //    await _context.SaveChangesAsync();
        //}

        //public async void AddConstituencyAreas(List<ConstituencyArea> constituencyAreas)
        //{
        //    _context.ConstituencyArea.AddRange(constituencyAreas);
        //    await _context.SaveChangesAsync();
        //}

        //public async void AddParties(List<Party> partiesToAdd)
        //{
        //    _context.PoliticalParty.AddRange(partiesToAdd);
        //    await _context.SaveChangesAsync();
        //}

        public void ImportData()
        {
            throw new System.NotImplementedException();
        }

        public void ImportJoins()
        {
            throw new System.NotImplementedException();
        }

        public void ImportReferences()
        {
            throw new System.NotImplementedException();
        }
    }
}
