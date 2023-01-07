using Application.Interface;
using Domain.Interface;
using Domain.Repository;

namespace Application.Service
{

    public class MaintenanceServiceImp : MaintenanceService
    {
        private Maintenance _maintenance;
        private BaseContext _context;

        public MaintenanceServiceImp(Maintenance maintenance, BaseContext context)
        {
            _maintenance = maintenance;
            _context = context;
        }

        public async Task AddMaintenance(Data.Repository.Entity.Context.Maintenance maintenanceImp)
        {
            _context.Add(maintenanceImp);

            await _context.SaveChangesAsync();
        }

        public DateTime GetNextMaintenanceDate(int daysToAddDate)
        {
            var result = _maintenance.GetNextMaintenanceDate(daysToAddDate);

            return result;
        }
    }
}
