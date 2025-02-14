namespace FinancialGoals.Application.Services;

public interface IMessageService
{
    Task SendEmailAsync(string email, string subject, string message);
    Task SendSmsAsync(string number, string message);
}
