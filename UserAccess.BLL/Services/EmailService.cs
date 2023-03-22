using SendGrid;
using SendGrid.Helpers.Mail;
using UserAccess.BLL.Interfaces;

namespace UserAccess.BLL.Services;

public class EmailService : IEmailService
{
    private readonly ISendGridClient _sendGridClient;

    public EmailService(ISendGridClient sendGridClient)
    {
        _sendGridClient = sendGridClient;
    }
    
    public async Task SendEmailAsync(string toEmail, string subject, string message)
    {
        var msg = new SendGridMessage()
        {
            From = new EmailAddress("behoof.inc@gmail.com", "Behoof"),
            Subject = subject,
            PlainTextContent = message,
            HtmlContent = message
        };
        msg.AddTo(new EmailAddress(toEmail));

        var response = await _sendGridClient.SendEmailAsync(msg);
        
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception("Failed to send email");
        }
    }
}