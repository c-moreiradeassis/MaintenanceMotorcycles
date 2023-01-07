namespace Domain.Repository
{
    public interface BaseContext
    {
        void Add<T>(T entity) where T : class;
        Task SaveChangesAsync();
    }
}
