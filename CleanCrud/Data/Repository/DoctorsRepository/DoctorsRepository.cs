using CleanCrud.Models;

namespace CleanCrud.Data;

public class DoctorsRepository : GenericRepo<Doctor>, IDoctorsRepository
{
    private HospitalContext _context;
    public DoctorsRepository(HospitalContext injectedContext) : base(injectedContext)
    {
        _context = injectedContext;
    }

    public List<Doctor> GetDoctorsByAuthorName(string AuthorName)
    {
        return _context.Doctors.Where(b => b.Specialization == AuthorName).ToList();
    }
}
