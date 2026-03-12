using VaultManager.DataModel;
using System.Text.Json;
using System.IO;


namespace VaultManager.Vault;

public delegate void VaultUpdateHandler(string message);
public class VaultManager
{
    public event VaultUpdateHandler OnVaultUpdate;

    // File name
    private const string Filename = "vault.json";

    private List<PasswordEntry> _entries = [];

    public VaultManager()
    {
        InitializeStorage();
        LoadFromFile();
    }

    public async Task SaveEntryAsync(PasswordEntry entry, string masterKey)
    {
            await Task.Run(() => {
            // 1. Encrypt the password field only
            string encryptedPass = SecutrityUtils.SecurityUtils.Encrypt(entry.EncryptedPassword, masterKey);
            
            // 2. Create a copy to save so we don't mess up the object in memory
            var entryToSave = new PasswordEntry {
                ServiceName = entry.ServiceName,
                UserName = entry.UserName,
                EncryptedPassword = encryptedPass
            };

            _entries.Add(entryToSave);
            
            // 3. Write to disk
            string json = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(Filename, json);
        });

        OnVaultUpdate?.Invoke($"Encrypted and saved {entry.ServiceName} to disk.");

    }

    public List<PasswordEntry> GetPasswordEntries() => _entries;

    public void LoadFromFile()
    {
        if(File.Exists(Filename))
        {
            string json = File.ReadAllText(Filename);
            _entries = JsonSerializer.Deserialize<List<PasswordEntry>>(json) ?? [];
            
        }
    }

    private void InitializeStorage()
    {
        try 
        {
            // Check if file exists
            if (!File.Exists(Filename))
            {
                // Create an empty list and serialize it to start fresh
                string initialJson = JsonSerializer.Serialize(new List<PasswordEntry>());
                File.WriteAllText(Filename, initialJson);
                
                // Trigger event to let the UI know a new vault was created
                OnVaultUpdate?.Invoke("No existing vault found. Created a new secure storage file.");
            }
        }
        catch (IOException ex)
        {
            Console.WriteLine($"[CRITICAL ERROR]: Could not create storage file. {ex.Message}");
        }
    }

}