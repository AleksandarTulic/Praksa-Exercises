using System.ComponentModel.DataAnnotations;

namespace StudentService.Models{
    public class Student{
        [Key]
        public Guid Id { get; set; }
        public string Name {get; set;}
        public string Surname { get; set; }
        public string Index {get; set;}
        public virtual CollegeYear CollegeYear {get; set;}
        public DateTimeOffset Birthday {get; set;}
        public DateTimeOffset Enrolled{get; set;}
    }
}