namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class GovernmentRank
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? MinisterialRank { get; set; }
        public string StatsRank { get; set; }
        public string ClerksRank { get; set; }
        public int? OrderRank { get; set; }
    }
}
