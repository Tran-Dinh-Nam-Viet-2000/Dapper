using Microsoft.AspNetCore.Mvc;
using Test_Dapper.Dtos;
using Test_Dapper.Entites;
using Test_Dapper.Repositories.Interface;

namespace Test_Dapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _studentRepository.GetAll());
        }

        [HttpGet("Sp_GetAll")]
        public async Task<IActionResult> SP_GetAll()
        {
            return Ok(await _studentRepository.SP_GetAll());
        }

        [HttpPost("Sp_CreateStudent")]
        public void Sp_CreateStudent(Student studentDto)
        {
            _studentRepository.Create(studentDto);
        }

        [HttpGet("id")]
        public Student Sp_GetById(int id)
        {
            return _studentRepository.SP_GetById(id);
        }

        [HttpPut]
        public void Update(StudentDto studentDto, int id)
        {
            _studentRepository.Update(studentDto, id);
        }

        [HttpDelete("id")]
        public void Delete(int id)
        {
            _studentRepository.Delete(id);
        }
    }
}
