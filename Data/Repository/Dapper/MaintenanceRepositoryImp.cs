using Dapper;
using Domain.Models;
using Domain.Repository;
using System.Data.SqlClient;

namespace Data.Repository.Dapper
{
    public class MaintenanceRepositoryImp : Domain.Repository.MaintenanceRepository
    {
        private readonly string _connectionString;

        public MaintenanceRepositoryImp(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<MaintenanceImp>> GetMaintenances(int idClient, DateTime lastMaintenance)
        {
            IEnumerable<MaintenanceImp> maintenances = new List<MaintenanceImp>();

            var query = $@"SELECT C.EMAIL {nameof(MaintenanceImp.Email)}
                                  ,M.ITEM {nameof(MaintenanceImp.Item)}
                                  ,M.OPERATION {nameof(MaintenanceImp.Operation)}
                                  ,CM.LAST_MAINTENANCE {nameof(MaintenanceImp.LastMaintenance)}
                             FROM CLIENT_MAINTENANCE CM
                                  INNER JOIN MAINTENANCE M ON M.ID = CM.ID_MAINTENANCE
	                              INNER JOIN CLIENT C ON C.ID = CM.ID_CLIENT
                            WHERE CM.ID_CLIENT = @idClient
                              AND CM.LAST_MAINTENANCE = @lastMaintenance";

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                maintenances = await sqlConnection.QueryAsync<MaintenanceImp>(
                    query,
                    new { idClient, lastMaintenance });
            }

            return maintenances;
        }
    }
}
