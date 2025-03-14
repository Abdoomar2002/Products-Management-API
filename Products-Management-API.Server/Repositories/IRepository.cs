namespace Products_Management_API.Server.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveChanges();
    }
}
