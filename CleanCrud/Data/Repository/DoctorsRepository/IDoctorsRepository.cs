using CleanCrud.Models;

namespace CleanCrud.Data;

public interface IDoctorsRepository : IGenericRepo<Doctor>
{
    List<Doctor> GetDoctorsByAuthorName(string AuthorName);
}