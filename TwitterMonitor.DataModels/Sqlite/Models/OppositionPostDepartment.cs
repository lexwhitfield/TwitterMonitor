namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class OppositionPostDepartment
    {
        public int Id { get; set; }
        public int OppositionPostId { get; set; }
        public int DepartmentId { get; set; }


        public OppositionPost OppositionPost { get; set; }
        public Department Department { get; set; }
    }
}
