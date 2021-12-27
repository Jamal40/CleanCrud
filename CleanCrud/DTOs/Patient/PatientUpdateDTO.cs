namespace CleanCrud.DTOs;

public class PatientUpdateDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string IssuesIds { get; set; }
}
