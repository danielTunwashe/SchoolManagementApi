using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagemetApi.Application.Services.Interface;
using SchoolManagemetApi.Domain.DTO.FacultyDto_s;
using SchoolManagemetApi.Domain.Model;

namespace SchoolManagemetApi.Controllers
{
    [ApiController]
    [Route("api/faculty")]
    public class FacultyController : Controller
    {
        private readonly IFacultyRepository _faultyRepository;

        public FacultyController(IFacultyRepository faultyRepository)
        {
            _faultyRepository = faultyRepository;
        }

        [HttpPost]
        public async Task<IActionResult> PostFaculty([FromBody] CreateFacultyInputDto input)
        {
            var result = await _faultyRepository.Add(input);
            return Ok(result);
        }

        [HttpDelete("/deleteFaculty/{id}")]
        public async Task<IActionResult> DeleteFaculty([FromRoute] int id)
        {
            var result = await _faultyRepository.Delete(id);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFaculty([FromBody] UpdateFacultyInputDto input)
        {
            var result = await _faultyRepository.Update(input);
            return Ok(result);  
        }

        [HttpGet]
        public async Task<ActionResult<List<Faculty>>> GetAllFaculty()
        {
            var result = await _faultyRepository.GetAll();
            return Ok(result);
        }

        [HttpGet("getDepartmentById/{id}")]
        public async Task<ActionResult<Faculty>> GetDepartmentById(int id)
        {
            var result = await _faultyRepository.GetById(id);
            return Ok(result);
        }
        
    }
}
