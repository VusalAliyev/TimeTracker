using System.Net.Mail;
using TimeTracker.Application.Common;

namespace TimeTracker.WebAPI.Services
{
    public class ReminderBy : IReminderBy
    {
        public void RemindByEmail(string to,string content)
        {
            SmtpClient SmtpServer = new SmtpClient("smtp.office365.com");
            var mail = new MailMessage();
            mail.From = new MailAddress("vusal_aliev@hotmail.com");
            mail.To.Add(to);
            mail.Subject = "Reminder";
            mail.IsBodyHtml = true;
            string htmlBody;
            htmlBody = $"<b>{content}</b> some HTML code here";
            mail.Body = htmlBody;
            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("vusal_aliev@hotmail.com", "vusal278");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }

        public void RemindByTelegram()
        {
            throw new NotImplementedException();
        }
    }
}
