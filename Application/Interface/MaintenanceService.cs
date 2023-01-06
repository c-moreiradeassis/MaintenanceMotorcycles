using Domain.Models;

namespace Application.Interface
{
    public interface MaintenanceService
    {
        DateTime GetNextMaintenanceDate(int daysToAddDate);
        Task AddMaintenance(MaintenanceImp maintenanceImp);
    }
}
