using Microsoft.EntityFrameworkCore;
using SchoolManagemetApi.Application.Services.Interface;
using SchoolManagemetApi.DataAccess.DataContext;
using SchoolManagemetApi.Domain.DTO.FacultyDto_s;
using SchoolManagemetApi.Domain.Model;

namespace SchoolManagemetApi.Application.Services.Repository
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly AppDbContext _appDbContext;
        public FacultyRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<string> Add(CreateFacultyInputDto input)
        {
            try
            {
                var faculty = new Faculty()
                {
                    Name = input.Name,
                    YearCreated = input.YearCreated,
                };

                await _appDbContext.Faculties.AddAsync(faculty);
                await _appDbContext.SaveChangesAsync();

                return "Faculty created successfully";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Delete(int id)
        {
            var faculty = await _appDbContext.Faculties.FirstOrDefaultAsync(x => x.Id == id);
            if (faculty == null)
            {
                throw new Exception($"The faculty of id: {id} does not exist in the database");
            }
            _appDbContext.Faculties.Remove(faculty);
            await _appDbContext.SaveChangesAsync();

            return "Faculty Deleted Successfully";
        }

        public async Task<List<Faculty>> GetAll() => await _appDbContext.Faculties.ToListAsync();
        

        public async Task<Faculty> GetById(int id)
        {
            var faculty = await _appDbContext.Faculties.Include(d=>d.Departments).FirstOrDefaultAsync(x => x.Id == id);
            if(faculty == null)
            {
                throw new Exception($"Faculty with ID {id} deos not exist in the database");
            }
            return faculty;

        }

        public async Task<string> Update(UpdateFacultyInputDto input)
        {
            var faculty = await _appDbContext.Faculties.FirstOrDefaultAsync(x => x.Id == input.Id);
            if (faculty == null)
            {
                throw new Exception($"Faculty with ID {input.Id} deos not exist in the database");
            }

            faculty.Name = input.Name;  
            faculty.YearCreated = input.YearCreated;    

            _appDbContext.Faculties.Update(faculty);
            await _appDbContext.SaveChangesAsync();
            return "Faculties Deleted Successfully";
        }
    }
}
