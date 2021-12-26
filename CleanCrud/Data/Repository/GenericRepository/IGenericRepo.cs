namespace CleanCrud.Data;

public interface IGenericRepo<T> where T : class
{
    T Get(Guid id);
    List<T> GetAll();
    void Create(T entity);
    void Update(T entity);
    void Delete(Guid id);
    bool CheckExistence(Guid id);
    int SaveChanges();
}
