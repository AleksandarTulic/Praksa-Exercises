namespace StudentService.Models.Dtos.Incoming{
    public record StudentIncomingDto(
        Guid CollegeYearId, string Name, string Surname, 
        string Index, DateTimeOffset Birthday
    );
}