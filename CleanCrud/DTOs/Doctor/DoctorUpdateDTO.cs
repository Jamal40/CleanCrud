namespace CleanCrud.Models.DTOs;

public record DoctorUpdateDTO
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Specialization { get; init; }
}
