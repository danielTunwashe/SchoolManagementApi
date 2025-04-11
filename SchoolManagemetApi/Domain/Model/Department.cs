namespace SchoolManagemetApi.Domain.Model
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string YearCreated { get; set; }

        public int FacultyId { get; set; }
    }
}
