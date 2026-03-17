namespace KiranaAppV1.Core.DTOs.Requests;
public class UserRequestDTO
{
    public required string Username { get; set; }
    public string Password { get; set; }

    public string ConfirmPassword{get; set;}

    public string Email{get;set;}
    public string Role { get; set; }
}