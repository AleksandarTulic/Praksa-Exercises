using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.Models;
using StudentService.Models.DTOs.Incoming;
using StudentService.Models.DTOs.Outgoing;

namespace StudentService.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase{
    
        private readonly StudentContext studentContext;
        private readonly IMapper mapper;

        public StudentController(StudentContext studentContext, IMapper mapper){
            this.studentContext = studentContext;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentOutgoingDTO>>> GetAsync(){
            var items = await (studentContext.Students.FirstOrDefaultAsync<Student>());

            var itemsConverted = mapper.Map<IEnumerable<StudentOutgoingDTO>>(items);
            return Ok(itemsConverted);
        }

        [HttpGet("/{id}")]
        public async Task<ActionResult<Student>> GetByIdAsync(Guid id){
            var item = await studentContext.Students.FindAsync(id);

            var itemConverted = mapper.Map<StudentOutgoingDTO>(item);
            return item == null ? NotFound() : Ok(itemConverted);
        }

        [HttpPost]
        public async Task<ActionResult<Student>> PostAsync([FromBody] StudentIncomingDTO studentIncomingDTO){
            Console.WriteLine(studentIncomingDTO.CollegeYearId + " " + studentIncomingDTO.Name);
            Student student = mapper.Map<Student>(studentIncomingDTO);

            await studentContext.Students.AddAsync(student);
            
            return CreatedAtAction(nameof(GetByIdAsync), new {Id = student.Id}, student);
        }
    }
}