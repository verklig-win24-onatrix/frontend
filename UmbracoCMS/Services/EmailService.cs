using Azure;
using Azure.Communication.Email;

namespace UmbracoCMS.Services;

public class EmailService
{
  private readonly EmailClient _emailClient;
  private readonly string _fromAddress;

  public EmailService(IConfiguration config)
  {
    var connectionString = config["AzureCommunicationServices:ConnectionString"];
    _fromAddress = config["AzureCommunicationServices:FromEmail"];

    _emailClient = new EmailClient(connectionString);
  }

  public async Task<bool> SendEmailAsync(string toEmail, string subject, string body)
  {
    try
    {
      var emailMessage = new EmailMessage(
        senderAddress: _fromAddress,
        recipients: new EmailRecipients([new(toEmail)]),
        content: new EmailContent(subject)
        {
          PlainText = body,
          Html = $"<p>{body}</p>"
        });

      EmailSendOperation emailSendOperation = await _emailClient.SendAsync(WaitUntil.Completed, emailMessage);

      return emailSendOperation.HasCompleted && emailSendOperation.Value.Status == EmailSendStatus.Succeeded;
    }
    catch (Exception ex)
    {
      Console.WriteLine($"[EmailService] Failed to send email: {ex.Message}");
      return false;
    }
  }
}