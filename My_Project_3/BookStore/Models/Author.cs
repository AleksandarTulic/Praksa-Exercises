using System.ComponentModel.DataAnnotations;
using MyRepository.PostgreSQL;

namespace BookStore.Models{
    public class Author : Entity{
        [Required]
        public string Name {get; set;} = "";
        [Required]
        public string Surname {get; set;} = "";
        public DateTimeOffset Birtday {get; set;}

        public virtual ICollection<Book> Books {get; set;}
    }
}