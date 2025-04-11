using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagemetApi.Application.Services.Interface;
using SchoolManagemetApi.Domain.DTO.DepartmentDto_s;
using SchoolManagemetApi.Domain.Model;

namespace SchoolManagemetApi.Controllers
{
    [ApiController]
    [Route("api/department")]
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DepartmentController(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;  
        }

        [HttpPost]
        public async Task<IActionResult> PostDepartment([FromBody] CreateDepartmentDto input)
        {
            var result = await _departmentRepository.Add(input);
            return Ok(result);  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment([FromRoute] int id)
        {
            var result = _departmentRepository.Delete(id);
            return Ok(result);  
        }

        [HttpGet]
        public async Task<ActionResult<List<Department>>> GetAllDepartment()
        {
            var result = await _departmentRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("/byDeptId/{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById([FromRoute] int id)
        {
            var result = await _departmentRepository.GetById(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDepartment([FromBody] UpdateDepartmentInputDto input)
        {
            var result = await _departmentRepository.Update(input);
            return Ok(result);
        }
    }
}
