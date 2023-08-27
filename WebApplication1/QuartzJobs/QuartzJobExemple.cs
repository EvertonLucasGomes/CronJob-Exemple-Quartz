using Quartz;

namespace WebApplication1.QuartzJobs
{
    public class QuartzJobExemple : IJob
    {

        private readonly ILogger<QuartzJobExemple> _logger;

        public QuartzJobExemple(ILogger<QuartzJobExemple> logger) { 
            _logger = logger;
        }

        public Task Execute(IJobExecutionContext context)
        {
            var tempExemple = new WeatherForecast
            {
                Date = DateTime.Now,
                TemperatureC = Random.Shared.Next(-20, 55),
            };

            _logger.LogWarning("Log From quartz job: temp Cº: {TemperatureC}, Temp Fº: {TemperatureF}", tempExemple.TemperatureC, tempExemple.TemperatureF);

            return Task.CompletedTask;
        }
    }
}
