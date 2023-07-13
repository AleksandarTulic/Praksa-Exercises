namespace StudentService.Models.DTOs.Outgoing{
    public record StudentOutgoingDTO(string Id, string Name, string Surname,
        string Index, int CollegeYear, string Birthday, string Enrolled);
}