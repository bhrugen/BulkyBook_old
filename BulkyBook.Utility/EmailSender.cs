using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.Utility
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailOptions emailOptions;

        public EmailSender(IOptions<EmailOptions> options)
        {
            emailOptions = options.Value;
        }
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            return Execute(emailOptions.SendGridKey, subject, htmlMessage, email);
        }
        private Task Execute(string sendGridKEy, string subject,string message, string email)
        {
            var client = new SendGridClient(sendGridKEy);
            var from = new EmailAddress("admin@bulky.com", "Bulky Books");
            var to = new EmailAddress(email, "End User");
            var msg = MailHelper.CreateSingleEmail(from, to, subject, "", message);
            return client.SendEmailAsync(msg);
        }
    }
}
