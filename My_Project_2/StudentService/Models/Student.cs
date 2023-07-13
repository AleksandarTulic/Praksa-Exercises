using System.ComponentModel.DataAnnotations;
using MyRepository.PostgreSQL;

//DATA ANNOTATIONS

namespace StudentService.Models{
    public class Student : Entity{
        [Required(ErrorMessage = "You need to provide the Name of a student")]
        [StringLength(100)]
        public string Name {get; set;} = "";
        [Required(ErrorMessage = "You need to provide the Surname of a student")]
        [StringLength(100)]
        public string Surname {get; set;} = "";
        [Required(ErrorMessage = "You need to provide the Index of a student")]
        [StringLength(10)]
        public string Index {get; set;} = "";
        public DateTimeOffset Birthday {get; set;}
        public DateTimeOffset Enrolled {get; set;}

        public Guid CollegeYearId {get; set;}
        public virtual required CollegeYear CollegeYear {get; set;}
    }
}