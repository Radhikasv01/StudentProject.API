using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Student.Interface;
using Student.Model;
using Student.Model.Student.Model;

namespace Student.Service
{
    public class EmailService : IEmail
    {
        private readonly EmailSettings _settings;

        public EmailService(IOptions<EmailSettings> options)
        {
            _settings = options.Value; // Get email settings from configuration
        }

        // Send email directly
        public async Task SendEmailAsync(EmailModel emailModel)
        {
            var message = new MailMessage
            {
                From = new MailAddress(_settings.SenderEmail),
                Subject = emailModel.Subject,
                Body = emailModel.Body,
                IsBodyHtml = true
            };

            // If emailModel.To is a list of recipients, add each one
            foreach (var recipient in emailModel.To)
            {
                message.To.Add(recipient);  // Add each recipient to the "To" field
            }

            // SMTP client configuration
            using var smtp = new SmtpClient(_settings.SmtpServer, _settings.SmtpPort)
            {
                Credentials = new NetworkCredential(_settings.SenderEmail, _settings.SenderPassword),
                EnableSsl = true
            };

            // Send email asynchronously
            await smtp.SendMailAsync(message);
        }
    }
}
