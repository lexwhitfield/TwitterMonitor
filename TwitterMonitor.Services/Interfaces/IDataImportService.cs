namespace TwitterMonitor.Services.Interfaces
{
    public interface IDataImportService
    {
        void ImportReferences();
        void ImportData();
        void UpdateData();
        void ImportJoins();
        void ImportMembers();
        void ImportTwitter();
        void Tweet();
    }
}
