using System.Text;
using System.Security.Cryptography;

namespace VaultManager.SecutrityUtils;

public static class SecurityUtils
{
    private static readonly byte[] Salt = Encoding.UTF8.GetBytes("StaticSalt123");

    public static string Encrypt(string plainText, string masterKey)
    {
        using Aes aes = Aes.Create();
        var deriveBytes = new Rfc2898DeriveBytes(masterKey, Salt, 10000, HashAlgorithmName.SHA256);
        aes.Key = deriveBytes.GetBytes(32); // 256 bit key
        aes.IV = deriveBytes.GetBytes(16); // 128 bit IV

        using var encryptor = aes.CreateEncryptor();
        byte[] inputBytes = Encoding.UTF8.GetBytes(plainText);
        byte[] encryptedBytes = encryptor.TransformFinalBlock(inputBytes,0,inputBytes.Length);

        return Convert.ToBase64String(encryptedBytes);

    }

    public static string Decrypt(string cipherText, string masterKey)
    {
        try {
            using Aes aes = Aes.Create();
            var deriveBytes = new Rfc2898DeriveBytes(masterKey, Salt, 10000, HashAlgorithmName.SHA256);
            aes.Key = deriveBytes.GetBytes(32);
            aes.IV = deriveBytes.GetBytes(16);

            using var decryptor = aes.CreateDecryptor();
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedBytes = decryptor.TransformFinalBlock(cipherBytes, 0, cipherBytes.Length);
            
            return Encoding.UTF8.GetString(decryptedBytes);
        }
        catch {
            return "[Error: Invalid Master Key]";
        }
    }

    public static string GetHiddenInput()
    {
        string input = "";
        ConsoleKeyInfo keyInfo;

        do
        {
            keyInfo = Console.ReadKey(true);

            if(keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter)
            {
                input += keyInfo.KeyChar;
                Console.Write("*");
            }
            else if ( keyInfo.Key == ConsoleKey.Backspace && input.Length > 0)
            {
                input = input.Substring(0,(input.Length -1));
                Console.Write("\b \b");
            }
        } while (keyInfo.Key != ConsoleKey.Enter);

        Console.WriteLine();
        return input;
    }
}