using Event_System.Core.Entity.DTOs;

namespace Event_System.Persistance.Interface
{
    public interface IRepository<T>
    {
        string Add(T entity);
        List<T> GetAll();

        string Update(EventUpdate eventUpdate);

        string Delete(int Id, string userId);
        void SaveChanges();
    }
}
