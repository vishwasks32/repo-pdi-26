using VaultManager.DataModel;

namespace VaultManager.Vault;

public delegate void VaultUpdateHandler(string message);
public class VaultManager
{
    public event VaultUpdateHandler OnVaultUpdate;

    private List<PasswordEntry> _entries = new List<PasswordEntry>();

    public async Task SaveEntryAsync(PasswordEntry entry)
    {
        await Task.Run(() =>
        {
            _entries.Add(entry);
            System.Threading.Thread.Sleep(1000);
        });

        OnVaultUpdate?.Invoke($"Successfully added {entry.ServiceName} to the vault.");


    }

    public List<PasswordEntry> GetPasswordEntries() => _entries;

}