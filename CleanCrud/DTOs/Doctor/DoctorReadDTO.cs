namespace CleanCrud.Models.DTOs;

public record DoctorReadDTO()
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Specialization { get; init; }
    public int PerformanceRate { get; init; }
}
