using System.ComponentModel.DataAnnotations;
using MyRepository.PostgreSQL;

namespace StudentService.Models{
    public class CollegeYear : Entity{

        public CollegeYear(){
            Students = new List<Student>();
        }

        [Required(ErrorMessage = "You need to provide college year")]
        [Range(1, 6)]
        public int Year {get; set;}

        public virtual ICollection<Student> Students {get; set;}
    }
}