namespace Domain.Repository
{
    public interface BaseContext
    {
        void AddMaintenance<T>(T entity) where T : class;
    }
}
