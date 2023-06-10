using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTeste
{
    public class JobImplementacion2 : IJob
    {
        private readonly ILogger<JobImplementacion2> _logger;

        public JobImplementacion2(ILogger<JobImplementacion2> logger)
        {
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Rodando: job 2 {time}",DateTime.Now);
            return Task.CompletedTask;
        }
    }
}
