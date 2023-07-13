using System.ComponentModel.DataAnnotations;

namespace StudentService.Models{
    public class CollegeYear{
        [Key]
        public Guid Id {get; set;}
        public int Year {get; set;}

        public CollegeYear(){
            this.Students = new HashSet<Student>();
        }

        public CollegeYear(Guid id){
            this.Id = id;
        }

        public CollegeYear(Guid id, int year){
            this.Id = id;
            this.Year = year;
        }

        public virtual ICollection<Student> Students {get; set;}
    }
}