namespace TwitterMonitor.DataAccess.Interfaces
{
    public interface IDataImportRepository
    {
        void ImportReferences();
        void ImportData();
        void ImportJoins();
    }
}
