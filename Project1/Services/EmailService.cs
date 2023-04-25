using Infrastructure;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services
{
    public class EmailService : IEmailServices
    {
        private readonly EmailSetting _emailSetting;
        private readonly IHostingEnvironment _env;

        public EmailService(
            IOptions<EmailSetting> emailsetting,
            IHostingEnvironment env)
        {
            _emailSetting = emailsetting.Value;
            _env = env;
        }
        public async Task SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                var mimeMessage = new MimeMessage();
                mimeMessage.From.Add(new MailboxAddress(_emailSetting.SenderName, _emailSetting.Sender));
                mimeMessage.To.Add(new MailboxAddress(email));
                mimeMessage.Subject = subject;
                mimeMessage.Body = new TextPart("html")
                {
                    Text = message
                };

                var client = new SmtpClient();
                client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                if (_env.IsDevelopment())
                {
                    // The third parameter is useSSL (true if the client should make an SSL-wrapped
                    // connection to the server; otherwise, false).
                    await client.ConnectAsync(_emailSetting.MailServer, _emailSetting.MailPort,SecureSocketOptions.Auto);
                }
                else
                {
                    await client.ConnectAsync(_emailSetting.MailServer);
                }

                // Note: only needed if the SMTP server requires authentication
                await client.AuthenticateAsync(_emailSetting.Sender, _emailSetting.Password);

                await client.SendAsync(mimeMessage);

                await client.DisconnectAsync(true);

            }
            catch (Exception ex)
            {
                // TODO: handle exception
                throw new InvalidOperationException(ex.Message);


            }
        }
    }
}
