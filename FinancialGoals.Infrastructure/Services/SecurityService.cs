using FinancialGoals.Application.Services;

using System.Security.Cryptography;
using System.Text;

namespace FinancialGoals.Infrastructure.Services;

public class SecurityService : ISecurityService
{
    private static readonly string Key = "qwertyuiopmnbvcxzghjklçfdsa";
    public string EncryptPassword(string password)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = new byte[16]; // Initialization vector with zeros

            ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter sw = new StreamWriter(cs))
                    {
                        sw.Write(password);
                    }
                }

                return Convert.ToBase64String(ms.ToArray());
            }
        }
    }
    public bool VerifyPassword(string password, string passwordHash)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(Key);
            aes.IV = new byte[16]; // Initialization vector with zeros

            ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream ms = new MemoryStream(Convert.FromBase64String(passwordHash)))
            {
                using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader sr = new StreamReader(cs))
                    {
                        string decryptedPassword = sr.ReadToEnd();
                        return decryptedPassword == password;
                    }
                }
            }
        }
    }
}
  
