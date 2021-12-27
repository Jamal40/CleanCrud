using System.ComponentModel.DataAnnotations.Schema;

namespace CleanCrud.Models;

public class Doctor
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Specialization { get; set; }

    [Column(TypeName = "money")]
    public decimal Salary { get; set; }
    public int PerformanceRate { get; set; }
}
