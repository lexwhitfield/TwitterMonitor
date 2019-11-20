namespace TwitterMonitor.Services.Interfaces
{
    public interface ITwitterService
    {
        void NewOrUpdatedTwitterDetails(string screenName, long? id, bool forceUpdate = false);
    }
}
