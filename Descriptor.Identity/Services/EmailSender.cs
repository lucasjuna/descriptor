﻿using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Descriptor.Identity.Services
{
	public class EmailSender : IEmailSender
	{
		private readonly AppSettings _options;

		public EmailSender(IOptions<AppSettings> options)
		{
			_options = options.Value;
		}

		public Task SendEmailAsync(string email, string subject, string message)
		{
			return Execute(_options.SendGridKey, subject, message, email);
		}

		public Task Execute(string apiKey, string subject, string message, string email)
		{
			var client = new SendGridClient(apiKey);
			var msg = new SendGridMessage()
			{
				From = new EmailAddress(_options.SendGridEmail),
				Subject = subject,
				PlainTextContent = message,
				HtmlContent = message
			};
			msg.AddTo(new EmailAddress(email));
			msg.SetClickTracking(false, false);

			return client.SendEmailAsync(msg);
		}
	}
}
