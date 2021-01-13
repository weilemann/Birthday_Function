using System;
using System.Threading.Tasks;
using BirthdayFunction.Services;
using BirthdayFunction.Templates;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace BirthdayFunction
{
    public static class BirthdayFunction
    {
        private static readonly string AppKey = Environment.GetEnvironmentVariable("Twitter_API_Key");
        private static readonly string AppKeySecret = Environment.GetEnvironmentVariable("Twitter_API_Key_Secret");
        private static readonly string AccessKey = Environment.GetEnvironmentVariable("Access_Key");
        private static readonly string AccessKeySecret = Environment.GetEnvironmentVariable("Access_Key_Secret");

        [FunctionName("Function1")]
        public static async Task RunAsync([TimerTrigger("0/10 * * * * *")] TimerInfo timer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            Congratulations congratulations = new Congratulations();

            string message = congratulations.GetRandomCongratulations();

            var twitter = new TwitterService(
                AppKey,
                AppKeySecret,
                AccessKey,
                AccessKeySecret
                );

            await twitter.TweetText(message, string.Empty);
        }
    }
}
