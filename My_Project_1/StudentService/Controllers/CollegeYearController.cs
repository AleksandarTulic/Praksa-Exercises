using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentService.Data;
using StudentService.Models;

namespace StudentService.Controllers{
    [ApiController]
    [Route("[controller]")]
    public class CollegeYearController : ControllerBase{
        
        private readonly StudentContext studentContext;

        public CollegeYearController(StudentContext studentContext){
            this.studentContext = studentContext;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<CollegeYear>>> GetAsync(){
            var items = await (studentContext.CollegeYears.ToListAsync());

            return items;
        }
    }
}