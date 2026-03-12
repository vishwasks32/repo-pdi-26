namespace VaultManager.App;

using VaultManager.Vault;
using VaultManager.DataModel;

class Program
{
    static async Task Main(string[] args)
    {
        VaultManager vault = new VaultManager();

        vault.OnVaultUpdate += (msg)=> Console.WriteLine($"\n[NOTIFICATION]: {msg}");

        Console.WriteLine("-----------Secure Console Vault----------------");
        Console.Write("Enter the master Key: ");
        string masterKey = SecutrityUtils.SecurityUtils.GetHiddenInput();

        bool running = true;
        while(running)
        {
            Console.WriteLine("\n1. Add Password\n2. View all\n3. Exit");
            string choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    Console.Write("Service: ");
                    string service = Console.ReadLine();
                    Console.WriteLine("Username: ");
                    string username = Console.ReadLine();
                    Console.WriteLine("Password: ");
                    string password = SecutrityUtils.SecurityUtils.GetHiddenInput();

                    var newEntry = new PasswordEntry
                    {
                        ServiceName = service,
                        UserName = username,
                        EncryptedPassword = password
                    };

                    await vault.SaveEntryAsync(newEntry, masterKey);
                    break;
                case "2":
                    var entries = vault.GetPasswordEntries();
                    Console.WriteLine("--------Entries in Vault ---");
                    foreach (var e in entries)
                    {
                        // Decrypt on the fly using the current session's masterKey
                        string decrypted = SecutrityUtils.SecurityUtils.Decrypt(e.EncryptedPassword, masterKey);
                        Console.WriteLine($"Service: {e.ServiceName} | User: {e.UserName} | Pass: {decrypted}");
                    }
                    break;

                case "3":
                    running = false;
                    break;
            }
        }


    }
}