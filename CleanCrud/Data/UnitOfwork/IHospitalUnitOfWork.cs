namespace CleanCrud.Data;

public interface IHospitalUnitOfWork
{
    IDoctorsRepository DoctorsRepository { get; }
}