using System.Net;
using System.Net.Mail;

namespace CRUD_Products.Services.Email.Service
{
    public class EmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(
            string address,
            string subject,
            string body)
        {   

            var mail = new MailMessage
            {
                From = new MailAddress("eduardovlmartins@outlook.com"),
                To = { address },
                Subject = subject,
                Body = body
            };

            var smtpClient = new SmtpClient("smtp.office365.com")
            {
                Port = 587,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("eduardovlmartins@outlook.com", "74774172Du."),
                EnableSsl = true
            };

            try
            {
                smtpClient.Send(mail);
            }
            catch (Exception ex)
            {
                return false;
            }

            return true;
        }
    }
}
