namespace Domain.Interface
{
    public interface Maintenance
    {
        DateTime GetNextMaintenanceDate(int daysToAddDate);
    }
}
