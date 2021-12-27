namespace CleanCrud.Models;

public class Patient
{
    public Patient()
    {
        Issues = new HashSet<Issue>();
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Issue> Issues { get; set; }
}
