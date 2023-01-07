namespace Application.Interface
{
    public interface MaintenanceService
    {
        DateTime GetNextMaintenanceDate(int daysToAddDate);
        Task AddMaintenance(Data.Repository.Entity.Context.Maintenance maintenanceImp);
    }
}
