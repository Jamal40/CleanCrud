namespace CleanCrud.DTOs;

public class PatientReadDTO
{
    public PatientReadDTO()
    {
        Issues = new HashSet<IssueChildReadDTO>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<IssueChildReadDTO> Issues { get; set; }
}
