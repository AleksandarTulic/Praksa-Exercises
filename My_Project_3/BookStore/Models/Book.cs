using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MyRepository.PostgreSQL;

namespace BookStore.Models{
    public class Book : Entity{
        [Required]
        public string Title {get; set;} = "";
        [Required]
        public string Description {get; set;} = "";
        [Required]
        public DateTimeOffset Published {get; set;}
        
        [Display(Name = "Author")]
        public virtual Guid AuthorId {get; set;}

        [ForeignKey("AuthorId")]
        public virtual Author Author {get; set;}

    }
}