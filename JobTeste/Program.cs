using JobTeste;
using log4net.Config;
using Quartz;


IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        XmlConfigurator.Configure(new FileInfo("log4net.config"));
        //provedor
        services.AddLogging(loggingBuilder =>
        {
            loggingBuilder.AddLog4Net(); // Adiciona o provedor de logging do Log4Net
        });
        
        services.AddQuartz(q =>
        {
            q.UseMicrosoftDependencyInjectionJobFactory();
            q.AddJobAndTrigger<JobImplementacion>(hostContext.Configuration);
            q.AddJobAndTrigger<JobImplementacion2>(hostContext.Configuration);
        });
        services.AddQuartzHostedService(q => q.WaitForJobsToComplete = true);
    })
    .Build();

await host.RunAsync();

