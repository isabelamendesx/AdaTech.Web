namespace DeliveryGuyAPI.Repositories
{
    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T? GetById(int id);
        void Add(T entity);
        void Update(T originalEntity, T updatedEntity);

        void Delete(T entity);
    }
}
