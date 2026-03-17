namespace KiranaAppV1.API.DTOs.Responses;

public class UserResponseDTO
{
    public required string Username { get; set; }
    public string Role { get; set; }

    public string? token{get; set;} = string.Empty;
    
    public UserResponseDTO(string username, string role)
    {
        Username = username;
        Role = role;
    }
}