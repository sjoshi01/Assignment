using System;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    public static string HashPassword(string password, string token)
    {
        using (var sha256 = SHA256.Create())
        {
            var tokenedPassword = token + password;
            var bytes = Encoding.UTF8.GetBytes(tokenedPassword);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }
    }

    public static string GenerateToken()
    {
        var tokenBytes = new byte[16];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(tokenBytes);
        }
        return Convert.ToBase64String(tokenBytes);
    }
}