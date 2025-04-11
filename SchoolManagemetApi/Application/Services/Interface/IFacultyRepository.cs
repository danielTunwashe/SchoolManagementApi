using SchoolManagemetApi.Domain.DTO.FacultyDto_s;
using SchoolManagemetApi.Domain.Model;

namespace SchoolManagemetApi.Application.Services.Interface
{
    public interface IFacultyRepository
    {
        Task<string> Add(CreateFacultyInputDto input);
        Task<string> Update(UpdateFacultyInputDto input);

        Task<string> Delete(int id);

        Task<List<Faculty>> GetAll();

        Task<Faculty> GetById(int id);
    }
}
