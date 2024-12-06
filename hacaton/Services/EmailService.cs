using MailKit.Net.Smtp;
using MimeKit;
using System.Threading.Tasks;

namespace hacaton.Services
{
	public class EmailService
	{
		private readonly string _smtpHost = "smtp.gmail.com"; // Gmail SMTP serveri
		private readonly int _smtpPort = 587;
		private readonly string _senderEmail = "ceyhunagayev08@gmail.com"; // Admin email
		private readonly string _senderPassword = "ifus gowg xmfn hlsg"; // Admin email password or App password

		// Email göndərmək üçün metod
		public async Task SendEmailAsync(string recipientEmail, string subject, string body)
		{
			var message = new MimeMessage();
			message.From.Add(new MailboxAddress("Admin", _senderEmail));
			message.To.Add(new MailboxAddress("", recipientEmail));
			message.Subject = subject;

			var bodyPart = new TextPart("plain")
			{
				Text = body
			};

			message.Body = bodyPart;

			using (var client = new SmtpClient())
			{
				await client.ConnectAsync(_smtpHost, _smtpPort, false);
				await client.AuthenticateAsync(_senderEmail, _senderPassword); // Gmail app password istifadə edin
				await client.SendAsync(message);
				await client.DisconnectAsync(true);
			}
		}
	}
}