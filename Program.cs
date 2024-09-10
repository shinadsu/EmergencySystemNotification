using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using EmergencySystemNotification.src;
using EmergencySystemNotification.Data.DatabaseService;
using EmergencySystemNotification.Repository;

namespace Program
{
	class Program
	{
		private static readonly List<string> EmailRecipients = new List<string>();

		private static async Task Main(string[] args)
		{
			// Initialize notification system
			var notifySystem = new NotifySystem("MESSAGE");

			// Configure database context options
			var dbContextOptions = new DbContextOptionsBuilder<DataContext>()
				.UseSqlServer("YOUR_CONNECTION_STRING_OR_CONFIG_FROM_JSON")
				.Options;

			// Update user list from the database
			await UpdateUserListAsync( dbContextOptions );

			// Initialize mail notification service
			var mailNotify = new MailNotify(EmailRecipients);

			// Subscribe to notifications
			notifySystem.notify += async msg =>
			{
				if ( string.IsNullOrEmpty( msg ) )
				{
					throw new ArgumentNullException( nameof( msg ) );
				}

				Console.WriteLine( msg );
				await mailNotify.onNotificationReceived( msg );
			};

			// Trigger notifications
			notifySystem.Notify();
		}

		private static async Task UpdateUserListAsync(DbContextOptions<DataContext> options)
		{
			if ( options == null )
			{
				throw new ArgumentNullException( nameof( options ) );
			}

			using var context = new DataContext(options);
			var userRepository = new UserRepository(context);
			var users = await userRepository.GET();

			EmailRecipients.Clear();
			EmailRecipients.AddRange( users.Select( user => user.Email ) );
		}
	}
}
