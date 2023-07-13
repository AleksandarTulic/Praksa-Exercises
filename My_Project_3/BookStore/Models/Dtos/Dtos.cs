using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Dtos{

    //For returning elements
    public class AuthorDto{
        public Guid Id{get; set;}
        public string Name{get; set;} = "";
        public string Surname{get; set;} = "";
        public DateTimeOffset Birthday{get; set;}
    };

    public class BookDto{
        public Guid Id {get; set;}
        public string Title { get; set; } = "";
        public string Description {get; set;} = "";
        public DateTimeOffset Published {get; set;}
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; } = "";
        public string AuthorSurname { get; set; } = "";
    }


    //For Creating elemens
    public record CreateAuthorDto([Required, MaxLength(100)] string Name, [Required, MaxLength(100)] string Surname, DateTimeOffset Birthday);
    public record CreateBookDto([Required, MaxLength(100)] string Title, [Required, MaxLength(100)] string Description, [Required] Guid AuthorId);

    //For Updating elements
    public record UpdateAuthorDto([Required, MaxLength(100)] string Name, [Required, MaxLength(100)] string Surname, DateTimeOffset Birthday);
    public record UpdateBookDto([Required, MaxLength(100)] string Title, [Required, MaxLength(100)] string Description, [Required] Guid AuthorId);
}