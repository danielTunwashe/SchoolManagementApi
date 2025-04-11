namespace SchoolManagemetApi.Domain.DTO.DepartmentDto_s
{
    public class UpdateDepartmentInputDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string YearCreated { get; set; }

        public int FacultyId { get; set; }
    }
}
