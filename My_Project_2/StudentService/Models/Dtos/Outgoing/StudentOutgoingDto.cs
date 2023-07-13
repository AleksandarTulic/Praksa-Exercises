namespace StudentService.Models.Dtos.Outgoing{
    public record StudentOutgoingDto(Guid Id, string Name,
        string Surname, string Index, DateTimeOffset Birthday, DateTimeOffset Enrolled, int CollegeYear);
}