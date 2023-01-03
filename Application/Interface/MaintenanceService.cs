namespace Application.Interface
{
    public interface MaintenanceService
    {
        DateTime GetNextMaintenanceDate(int daysToAddDate);
    }
}
