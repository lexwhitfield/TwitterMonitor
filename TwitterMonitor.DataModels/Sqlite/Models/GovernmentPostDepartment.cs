namespace TwitterMonitor.DataModels.Sqlite.Models
{
    public class GovernmentPostDepartment
    {
        public int Id { get; set; }
        public int GovernmentPostId { get; set; }
        public int DepartmentId { get; set; }


        public GovernmentPost GovernmentPost { get; set; }
        public Department Department { get; set; }
    }
}
