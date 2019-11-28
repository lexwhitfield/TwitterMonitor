namespace TwitterMonitor.Services.Interfaces
{
    public interface IDataImportService
    {
        void ImportAreas();
        void ImportConstituencies();
        void ImportConstituencyAreas();
        void ImportParties();
    }
}
