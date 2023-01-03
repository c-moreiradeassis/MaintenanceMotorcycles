using Dapper;
using Domain.Models;
using Domain.Repository;
using System.Data.SqlClient;

namespace Data.Repository.Dapper
{
    public class EmailRepositoryImp : EmailRepository
    {
        private string _connectionString;

        public EmailRepositoryImp(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<EmailImp>> GetEmails()
        {
            IEnumerable<EmailImp> emails = new List<EmailImp>();

            var query = $@"SELECT ID {nameof(EmailImp.Id)}
                                  ,EMAIL {nameof(EmailImp.Email)}
                             FROM CLIENT";

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                emails = await sqlConnection.QueryAsync<EmailImp>(query);
            }

            return emails;
        }
    }
}
