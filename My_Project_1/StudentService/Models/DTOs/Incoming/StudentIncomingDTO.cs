namespace StudentService.Models.DTOs.Incoming{
    public record StudentIncomingDTO(string Name, string Surname, string Index, Guid CollegeYearId, DateTimeOffset Birthday);
}