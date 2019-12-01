namespace TwitterMonitor.Services.Interfaces
{
    public interface IDataImportService
    {
        void ImportReferences();
        void ImportData();
        void ImportJoins();
        void ImportMembers();
    }
}
