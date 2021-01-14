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
        private static readonly string EmailUsername = Environment.GetEnvironmentVariable("Email_Username");
        private static readonly string EmailPassword = Environment.GetEnvironmentVariable("Email_Password");

        [FunctionName("BirthdayFunction")]
        public static async Task RunAsync([TimerTrigger("0/10 * * * * *")] TimerInfo timer, ILogger log)
        {
            log.LogInformation($"Birthday Function executed at: {DateTime.Now}");

            Congratulations congratulations = new Congratulations();

            string message = congratulations.GetRandomCongratulations("Jane", "John Doe");

            var emailClient = new EmailService(EmailUsername, EmailPassword);

            emailClient.SendEmail("John Doe", "jane_doe@gmail.com", "Feliz Aniversário", message);

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
