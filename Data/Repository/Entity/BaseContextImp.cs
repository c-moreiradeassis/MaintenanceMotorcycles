using Domain.Repository;

namespace Data.Repository.Entity
{
    public class BaseContextImp : BaseContext
    {
        private DataContext _context;

        public BaseContextImp(DataContext context)
        {
            _context = context;
        }

        public void AddMaintenance<T>(T entity) where T : class
        {
            _context.Maintenance.Add(entity);
        }
    }
}
