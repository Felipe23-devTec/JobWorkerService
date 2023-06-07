using JobTeste;
using Quartz;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionScopedJobFactory();
            q.AddJobAndTrigger<JobImplementacion>(hostContext.Configuration);
        });
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    })
    .Build();

await host.RunAsync();

