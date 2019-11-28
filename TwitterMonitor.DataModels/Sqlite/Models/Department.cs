using System;

namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Acronym { get; set; }
        public bool Minister { get; set; }
        public bool Secretary { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
