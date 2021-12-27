namespace CleanCrud.Models;

public class Issue
{
    public Issue()
    {
        Patients = new HashSet<Patient>(); 
    }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public ICollection<Patient> Patients { get; set; }
}
