using SchoolManagemetApi.Domain.DTO.DepartmentDto_s;
using SchoolManagemetApi.Domain.Model;

namespace SchoolManagemetApi.Application.Services.Interface
{
    public interface IDepartmentRepository
    {
        Task<string> Add(CreateDepartmentDto input);
        Task<string> Update(UpdateDepartmentInputDto input);

        Task<string> Delete(int id);

        Task<List<Department>> GetAll();

        Task<Department> GetById(int id);   
    }
}
