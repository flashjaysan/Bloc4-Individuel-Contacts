namespace Contacts.Business;

public interface IService<T>
{
    Task<T> GetItemById(int id);
    Task<T> Add(T t);
    Task<T> Update(T t);
    Task Delete(int id);
    Task<List<T>> GetAll();
}
