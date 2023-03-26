using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using UserAccess.BLL.Interfaces;

namespace UserAccess.BLL.Services;

public class EmailService : IEmailService
{
    private readonly IConfiguration _configuration;
    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var mailMessage = new MailMessage("bhoof.inc@gmail.com", toEmail);
        mailMessage.Subject = subject;
        mailMessage.Body = message;

        try
        {
            var smptClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("bhoof.inc@gmail.com", 
                    _configuration["Email:Password"]),
                EnableSsl = true
            };

            await smptClient.SendMailAsync(mailMessage);
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}