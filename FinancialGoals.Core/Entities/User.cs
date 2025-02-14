namespace FinancialGoals.Core.Entities;

public class User : BaseEntity
{
    public User(string email, string password, string firstName, string lastName)
    {
        Email = email;
        Password = password;
        FirstName = firstName;
        LastName = lastName;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; private set; }
    public string Password { get; private set; }
}