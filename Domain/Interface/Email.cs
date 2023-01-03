using Domain.Models;

namespace Domain.Interface
{
    public interface Email
    {
        void SendEmail(string to, List<MaintenanceImp> maintenances);
    }
}
