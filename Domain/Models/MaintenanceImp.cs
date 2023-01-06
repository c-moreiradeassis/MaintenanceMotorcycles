using Domain.Interface;

namespace Domain.Models
{
    public class MaintenanceImp : BaseEntity, Maintenance
    {
        public string? Email { get; set; }
        public string? Item { get; set; }
        public string? Operation { get; set; }
        public DateTime LastMaintenance { get; set; }

        public DateTime GetNextMaintenanceDate(int daysToAddDate)
        {
            LastMaintenance = DateTime.Today.AddDays(daysToAddDate);

            return LastMaintenance;
        }
    }
}
