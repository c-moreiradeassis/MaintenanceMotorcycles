using Domain.Interface;
using Domain.Models;

namespace Application.Interface
{
    public interface EmailService
    {
        Task<IEnumerable<EmailImp>> GetEmails();
        void SendEmail(string to, List<MaintenanceImp> maintenances);
    }
}
