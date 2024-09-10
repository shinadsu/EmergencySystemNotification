using System;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using Microsoft.Extensions.Options;
using MimeKit.Text;


namespace EmergencySystemNotification.src
{
	internal class MailNotify
	{	
		public List<string> _users;
		public MailNotify(List<string> strings) 
		{
			_users = strings;
		}


		public Task onNotificationReceived(string message)
		{
			return Execute(subject: "some message", message: message );	
		}


		public Task Execute(string subject, string message)
		{
			foreach ( var user in _users )
			{
				MimeMessage sender = new MimeMessage();
				sender.From.Add( new MailboxAddress( "TITLE", "YOUR_ADRESS" ) );
				sender.To.Add( new MailboxAddress( user, user ) );
				sender.Subject = subject;
				sender.Body = new TextPart()
				{
					Text = message
				};

				using ( var smtpClient = new SmtpClient() )
				{
					try
					{
						// Note: only needed if the SMTP server requires authentication
						smtpClient.Connect( "smtp.yandex.ru", 587, false );
						smtpClient.Authenticate( "YOUR_ADRESS_CREDENTIAL", "YOUR_ADRESS_CREDENTIAL" );
						smtpClient.Send( sender );
						
					}
					catch ( Exception ex )
					{
						throw new Exception( $"exception ocured while sending a message: {ex.Message}" );
					}
					finally
					{
						smtpClient.Disconnect( true );
						smtpClient.Dispose();
					}
				}

			}
			return Task.FromResult( true );
		}


	}
}