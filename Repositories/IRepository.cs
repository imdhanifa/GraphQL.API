
// ---------------------------------------------------------------------
// Repository interfaces and implementations.
// ---------------------------------------------------------------------
public interface IRepository<T>
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    T Add(T book);
    bool Delete(int id);
}
