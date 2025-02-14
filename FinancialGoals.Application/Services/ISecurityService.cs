namespace FinancialGoals.Application.Services;

public interface ISecurityService
{
    string EncryptPassword(string password);
    bool VerifyPassword(string password, string passwordHash);
    
    
}
