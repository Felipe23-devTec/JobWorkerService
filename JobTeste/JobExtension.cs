using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTeste
{
    public static class JobExtension
    {
        public static void AddJobAndTrigger<T>(
            this IServiceCollectionQuartzConfigurator quartz,
            IConfiguration config)
            where T : IJob
        {
            //Pegar nome da classe - mesmo nome da chave do config
            string nomeJob = typeof(T).Name;
      
            var configKey = $"Quartz:{nomeJob}";
            //Site para configurar tempo de execucao de um cron job https://www.vivaolinux.com.br/artigo/Como-executar-tarefas-a-cada-5-10-ou-15-minutos
            //https://crontab.guru/#5_3_*_*_*
            var cronHorarioExecucao = config[configKey]; //5seg

            if (string.IsNullOrEmpty(cronHorarioExecucao))
            {
                throw new Exception($"No Quartz.NET Cron schedule found for job in configuration at {configKey}");
            }

            //registrando o job
            var jobKey = new JobKey(nomeJob);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts => opts
                .ForJob(jobKey)
                .WithIdentity(nomeJob + "-trigger")
                .WithCronSchedule(cronHorarioExecucao));
        }
    }
}
