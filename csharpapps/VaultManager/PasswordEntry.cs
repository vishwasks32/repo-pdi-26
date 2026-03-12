namespace VaultManager.DataModel;

public class PasswordEntry
{
    public string ServiceName { get; set;}
    public string UserName { get; set;}
    public string EncryptedPassword { get; set;}
}