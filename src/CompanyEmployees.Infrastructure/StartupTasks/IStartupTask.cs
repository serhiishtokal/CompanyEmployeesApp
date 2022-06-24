namespace CompanyEmployeesApplication.StartupTasks
{
    public interface IStartupTask
    {
        Task ExecuteAsync(CancellationToken cancellationToken = default);
    }
}