using Quartz;

namespace WebApplication1.Extensions
{
    public static class JobExtension
    {
        public static void AddJobAndTrigger<T>(this IServiceCollectionQuartzConfigurator quartz, IConfiguration configuration) where T : IJob
        {
            string jobName = typeof(T).Name;

            var configKey = $"{jobName}:CronSchedule";
            var cronSchedule = configuration[configKey];

            if(string.IsNullOrEmpty(cronSchedule))
            {
                throw new Exception("Read error in cron Schedule");
            }

            var jobKey = new JobKey(jobName);
            quartz.AddJob<T>(opts => opts.WithIdentity(jobKey));

            quartz.AddTrigger(opts =>
                opts.ForJob(jobKey)
                .WithIdentity(jobName + "-trigger")
                .WithCronSchedule(cronSchedule));
                
        }
    }
}
