using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using EmergencySystemNotification.src;
using EmergencySystemNotification.Data.DatabaseService;
using EmergencySystemNotification.Repository;

namespace Program
{
	class Program
	{
		
	private static readonly List<string> EmailRecipients = new List<string>();

	// скрипт апдейта листа адресов
        private static async Task UpdateEmails(DbContextOptions<DataContext> options)
        {
            if (options == null)
            {
                throw new ArgumentNullException(nameof(options));
            }

            using var context = new DataContext(options);
            var userRepository = new UserRepository(context);
            var users = await userRepository.GET();

            EmailRecipients.Clear();
            EmailRecipients.AddRange(users.Select(user => user.Email));
        }

	// таска на отправку уведомления на почту
        private async static Task loadProcess()
        {
            var notifySystem = new NotifySystem("MESSAGE");
            var mailNotify = new MailNotify(EmailRecipients);

            notifySystem.notify += async msg =>
            {
                if (string.IsNullOrEmpty(msg))
                {
                    throw new ArgumentNullException(nameof(msg));
                }

                Console.WriteLine(msg);
                await mailNotify.onNotificationReceived(msg);
            };

            notifySystem.Notify();
        }

        private static async Task Main(string[] args)
		{
			// создаем переменную опций
			var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
				.UseSqlServer("YOUR_CONNECTION_STRING_OR_CONFIG_FROM_JSON")
				.Options;
			
			await UpdateEmails( dbContextOptions );
			await loadProcess();
		}

		

		
	}
}
