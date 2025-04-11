using Microsoft.EntityFrameworkCore;
using SchoolManagemetApi.Application.Services.Interface;
using SchoolManagemetApi.DataAccess.DataContext;
using SchoolManagemetApi.Domain.DTO.DepartmentDto_s;
using SchoolManagemetApi.Domain.Model;

namespace SchoolManagemetApi.Application.Services.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly AppDbContext _appDbContext;
         public DepartmentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> Add(CreateDepartmentDto input)
        {
            try
            {
                var checkFaculty = await _appDbContext.Faculties.FirstOrDefaultAsync(x=>x.Id == input.FacultyId);
                if(checkFaculty == null)
                {
                    throw new Exception("Faculty ID does not exists");
                }
                var department = new Department()
                {
                    Name = input.Name,
                    YearCreated = input.YearCreated,
                    FacultyId = input.FacultyId
                };
                await _appDbContext.Departments.AddAsync(department);
                await _appDbContext.SaveChangesAsync();
                return "Department created successfully";
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Delete(int id)
        {
            var department = await _appDbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                throw new Exception($"Deaprtment of Id: {id} does not exist in the database");
            }
            
            _appDbContext.Departments.Remove(department);
            await _appDbContext.SaveChangesAsync();
            return "Deleted Successfully";
        }

        public async Task<List<Department>> GetAll() => await _appDbContext.Departments.ToListAsync();
        

        public async Task<Department> GetById(int id)
        {
            var department = await _appDbContext.Departments.FirstOrDefaultAsync(x => x.Id == id);
            if (department == null)
            {
                throw new Exception($"Deaprtment of Id: {id} does not exist in the database");
            }

            return department;
        }

        public async Task<string> Update(UpdateDepartmentInputDto input)
        {
            var department = await _appDbContext.Departments.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (department == null)
            {
                throw new Exception($"Deaprtment of Id: {input.Id} does not exist in the database");
            }

            var faculty = await _appDbContext.Faculties.FirstOrDefaultAsync(x => x.Id == input.FacultyId);
            if (faculty == null)
            {
                throw new Exception($"Deaprtment of Id: {input.FacultyId} does not exist in the database");
            }

          
            department.Id = input.Id;
            department.Name = input.Name;
            department.YearCreated = input.YearCreated;
            department.FacultyId = input.FacultyId;

            _appDbContext.Departments.Update(department);
            await _appDbContext.SaveChangesAsync();

            return "Updated Successfully";
            
        }
    }
}
