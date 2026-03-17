namespace KiranaAppV1.API.DTOs.Responses;

public class UserResponseDTO
{
    public string Username { get; set; }
    public string Role { get; set; }

    public string? Token{get; set;} = string.Empty;
    
    public UserResponseDTO(string username, string role)
    {
        Username = username;
        Role = role;
    }

    public UserResponseDTO(string username, string role, string token)
    {
        Username = username;
        Role = role;
        Token = token;
    }
}