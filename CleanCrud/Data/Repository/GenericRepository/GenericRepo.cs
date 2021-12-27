namespace CleanCrud.Data;

public class GenericRepo<T> : IGenericRepo<T> where T : class
{
    private readonly HospitalContext context;

    public GenericRepo(HospitalContext injectedContext)
    {
        context = injectedContext;
    }
    public void Create(T entity)
    {
        context.Set<T>().Add(entity);
    }

    public void Delete(Guid id)
    {
        context.Set<T>().Remove(Get(id));
    }

    public T Get(Guid id)
    {
        return context.Set<T>().Find(id);
    }

    public List<T> GetAll()
    {
        return context.Set<T>().ToList();
    }

    public void Update(T entity)
    {

    }
    
    public bool CheckExistence(Guid id)
    {
        return context.Set<T>().Find(id) is not null;
    }
   
    public int SaveChanges()
    {
        return context.SaveChanges();
    }
}
