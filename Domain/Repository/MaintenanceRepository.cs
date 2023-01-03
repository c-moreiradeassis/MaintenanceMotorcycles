using Domain.Models;

namespace Domain.Repository
{
    public interface MaintenanceRepository
    {
        Task<IEnumerable<MaintenanceImp>> GetMaintenances(int idClient, DateTime lastMaintenance);
    }
}
