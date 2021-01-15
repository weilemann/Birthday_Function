using System;
using System.Data;
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

            DBService database = new DBService();

            var table = database.GetBirthdayPersons();

            foreach (DataRow row in table.Rows)
            {
                string firstName = row["Name"].ToString().Split(" ")[0];
                string email = row["Email"].ToString();
                string twitterName = row["TwitterName"].ToString();
                string message;

                Congratulations congratulations = new Congratulations();

                if (!string.IsNullOrEmpty(twitterName))
                {
                     message = congratulations.GetRandomCongratulations(twitterName, "John");

                    if (message.Length <= 240)
                    {
                        var twitter = new TwitterService(
                            AppKey,
                            AppKeySecret,
                            AccessKey,
                            AccessKeySecret
                        );

                        await twitter.TweetText(message, string.Empty);
                    }
                }

                message = congratulations.GetRandomCongratulations(firstName, "John Doe");

                var emailClient = new EmailService(EmailUsername, EmailPassword);

                emailClient.SendEmail("John Doe", email, "Feliz Aniversário", message);
            }
        }
    }
}
