namespace CleanCrud.Models.DTOs;

public record DoctorCreateDTO
{
    public string Name { get; init; }
    public string Specialization { get; init; }
    public decimal Salary { get; init; }
}
