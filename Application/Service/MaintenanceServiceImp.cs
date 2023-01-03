using Application.Interface;
using Domain.Interface;

namespace Application.Service
{

    public class MaintenanceServiceImp : MaintenanceService
    {
        private Maintenance _maintenance;

        public MaintenanceServiceImp(Maintenance maintenance)
        {
            _maintenance = maintenance;
        }

        public DateTime GetNextMaintenanceDate(int daysToAddDate)
        {
            var result = _maintenance.GetNextMaintenanceDate(daysToAddDate);

            return result;
        }
    }
}
