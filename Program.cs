using System;

using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using EmergencySystemNotification.src;
using Microsoft.EntityFrameworkCore;
using EmergencySystemNotification.Data.DatabaseService;
using EmergencySystemNotification.Repository;

namespace Program
{
	class Program
	{

		static List<string> optionsList = new List<string>();

		private static async Task Main(string[] args)
		{

			NotifySystem notifySystem = new NotifySystem("MESSAGE");

			var options = new DbContextOptionsBuilder<DataContext>()
				.UseSqlServer("YOUR_CONNECTION_STRING_OR_CONFIG_FROM_JSON").Options;

			await updateUserList( options );


			MailNotify mailNotify = new MailNotify(optionsList);

			notifySystem.notify += async (msg) => 
			{
				if ( msg == null )
					throw new ArgumentNullException(nameof(msg));

                Console.WriteLine(msg);
				await mailNotify.onNotificationReceived(msg);
			};

			notifySystem.Notify();

		}

		public static async Task updateUserList(DbContextOptions<DataContext> options)
		{
			if ( options == null ) 
				throw new ArgumentNullException("options");

			using ( var managaer = new DataContext( options ) )
			{
				var userRepo = new UserRepository(managaer);

				var users = await userRepo.GET();

				foreach ( var user in users )
				{
					optionsList.Add( user.Email );
				}
			}

		}


	}

	
}

 