using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyRepository.PostgreSQL;
using StudentService.Data;
using StudentService.Models;
using StudentService.Models.Dtos.Incoming;
using StudentService.Models.Dtos.Outgoing;

//
//dotnet nuget add source C:\Users\Windows10\Documents\.NET\My_Project_2\Packages\BUILDS -n Repository
//dotnet add package MyRepository.PostgreSQL
//

namespace StudentService.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase{

        private readonly StudentServiceContext repository;
        private readonly IMapper mapper;

        public StudentController(StudentServiceContext repository, IMapper mapper){
            this.repository = repository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentOutgoingDto>>> GetAsync(){
            var students = await repository.Students.GetAllAsync();
            var list = mapper.Map<IEnumerable<StudentOutgoingDto>>(students);

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetByIdAsync(Guid id){
            var student = await repository.Students.GetAsync(id);

            return student == null ? NotFound() : Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostAsync(StudentIncomingDto studentIncomingDto){
            Console.WriteLine("========================================");
            Console.WriteLine(studentIncomingDto.Name);
            Console.WriteLine(studentIncomingDto.Surname);
            Console.WriteLine(studentIncomingDto.Birthday);
            Console.WriteLine(studentIncomingDto.CollegeYearId);
            Console.WriteLine(studentIncomingDto.Index);
            Console.WriteLine("========================================");
            var student = mapper.Map<Student>(studentIncomingDto);
            student.CollegeYear = new CollegeYear{Id = Guid.NewGuid(), Year = 10};
            await repository.Students.CreateAsync(student);

            return CreatedAtAction(nameof(GetByIdAsync), new {Id = student.Id}, student);
        }

    }
}