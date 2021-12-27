namespace CleanCrud.Data;

public class HospitalUnitOfWork : IHospitalUnitOfWork
{
    public IDoctorsRepository DoctorsRepository { get; }
    public HospitalUnitOfWork(IDoctorsRepository doctorsRepository)
    {
        DoctorsRepository = doctorsRepository;
    }
}
