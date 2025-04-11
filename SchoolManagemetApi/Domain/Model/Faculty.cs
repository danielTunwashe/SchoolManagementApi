namespace SchoolManagemetApi.Domain.Model
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string YearCreated { get; set; }

        public List<Department> Departments { get; set; }
    }
}
