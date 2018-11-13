using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;

namespace API.Helper
{
    public static class EmailHelper
    {
        public static bool ValidarEmail(string email)
        {
            var rg = new Regex(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");
            return rg.IsMatch(email);
        }
        public static void SendMail(string destinatario, string body, string assunto)
        {
            using (var client = new SmtpClient(EnvironmentProperties.ContactHost, EnvironmentProperties.ContactPort))
            {
                client.UseDefaultCredentials = false;
                client.EnableSsl = true;
                client.Credentials = new System.Net.NetworkCredential(
                    EnvironmentProperties.OriginContactEmail,
                    EnvironmentProperties.EmailPassContact);

                using (var message = new MailMessage(EnvironmentProperties.OriginContactEmail, destinatario))
                {
                    message.IsBodyHtml = true;
                    message.Body = body; 
                    message.BodyEncoding = Encoding.UTF8;

                    message.Subject = assunto;
                    message.SubjectEncoding = Encoding.UTF8;

                    client.Send(message);

                }
            }
        }
    }
}