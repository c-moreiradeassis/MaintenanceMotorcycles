using Application.Interface;
using Domain.Interface;
using Domain.Models;
using Domain.Repository;

namespace Application.Service
{
    public class EmailServiceImp : EmailService
    {
        private Email _email;
        private EmailRepository _emailRepository;

        public EmailServiceImp(Email email, EmailRepository emailRepository)
        {
            _email = email;
            _emailRepository = emailRepository;
        }

        public Task<IEnumerable<EmailImp>> GetEmails()
        {
            var emails = _emailRepository.GetEmails();

            return emails;
        }

        public void SendEmail(string to, List<MaintenanceImp> maintenances)
        {
            _email.SendEmail(to, maintenances);
        }
    }
}
