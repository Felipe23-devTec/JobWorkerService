using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobTeste
{
    public class JobImplementacion : IJob
    {
        private readonly ILogger<JobImplementacion> _logger;

        public JobImplementacion(ILogger<JobImplementacion> logger)
        {
            _logger = logger;
        }
        public Task Execute(IJobExecutionContext context)
        {
            _logger.LogInformation("Rodando: {time}",DateTime.Now);
            return Task.CompletedTask;
        }
    }
}
