using Azure;
using Azure.Communication.Email;
using Azure.Communication.Sms;


using FinancialGoals.Application.Services;

using System.Net.Mail;

namespace FinancialGoals.Infrastructure.Services;

public class MessageService : IMessageService
{
    public async Task SendEmailAsync(string email, string subject, string message)
    {
        // This code demonstrates how to send email using Azure Communication Services.
        var connectionString = "<ACS_CONNECTION_STRING>";
        var emailClient = new EmailClient(connectionString);

        var sender = "<SENDER_EMAIL>";
        var recipient = "<RECIPIENT_EMAIL>";
        var htmlContent = "<html><body><h1>Quick send email test</h1><br/><h4>Communication email as a service mail send app working properly</h4><p>Happy Learning!!</p></body></html>";

        try
        {
            var emailSendOperation = await emailClient.SendAsync(
                wait: WaitUntil.Completed,
                senderAddress: sender, // The email address of the domain registered with the Communication Services resource
                recipientAddress: recipient,
                subject: subject,
                htmlContent: htmlContent);
            Console.WriteLine($"Email Sent. Status = {emailSendOperation.Value.Status}");

            /// Get the OperationId so that it can be used for tracking the message for troubleshooting
            string operationId = emailSendOperation.Id;
            Console.WriteLine($"Email operation id = {operationId}");
        }
        catch (RequestFailedException ex)
        {
            /// OperationID is contained in the exception message and can be used for troubleshooting purposes
            Console.WriteLine($"Email send operation failed with error code: {ex.ErrorCode}, message: {ex.Message}");
        }
    }

    public async Task SendSmsAsync(string number, string message)
    {
        var connectionString = "<connection-string>"; // Find your Communication Services resource in the Azure portal
        SmsClient smsClient = new SmsClient(connectionString);

        SmsSendResult sendResult = smsClient.Send(
            from: "<from-phone-number>", // Your E.164 formatted from phone number used to send SMS
            to: number, // E.164 formatted recipient phone number
            message: message);
        Console.WriteLine($"Message id {sendResult.MessageId}");

        Response<IReadOnlyList<SmsSendResult>> response = smsClient.Send(
        from: "<from-phone-number>",
        to: new string[] { "<to-phone-number-1>", "<to-phone-number-2>" }, // E.164 formatted recipient phone numbers
        message: "Hello 👋🏻",
        options: new SmsSendOptions(enableDeliveryReport: true) // OPTIONAL
        {
            Tag = "greeting", // custom tags
        });

        IEnumerable<SmsSendResult> results = response.Value;
        foreach (SmsSendResult result in results)
        {
            Console.WriteLine($"Sms id: {result.MessageId}");
            Console.WriteLine($"Send Result Successful: {result.Successful}");
        }
    }
}
