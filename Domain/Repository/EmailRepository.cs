using Domain.Models;

namespace Domain.Repository
{
    public interface EmailRepository
    {
        Task<IEnumerable<EmailImp>> GetEmails();
    }
}
