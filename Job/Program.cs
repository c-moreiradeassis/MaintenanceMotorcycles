using Infra;
using Job;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddServicesJob(hostContext.Configuration);
        services.AddHostedService<JobExecutor>();
    })
    .Build();

await host.RunAsync();
