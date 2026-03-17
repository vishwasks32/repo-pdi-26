using KiranaAppV1.API.DTOs.Responses;
using KiranaAppV1.Core.DTOs.Requests;
using Microsoft.AspNetCore.Identity;

namespace KiranaAppV1.Core.Interfaces;

public interface IAuthService
{
    Task<IdentityResult> RegisterAsync(UserRequestDTO userRequest);
    Task<UserResponseDTO> LoginAsync( UserRequestDTO userRequestDTO);
    Task<bool> IsUserExistsAsync(string username);
    Task<UserResponseDTO> GetUserByUsernameAsync(string username);

    Task<UserResponseDTO> GetById(Guid id);
}
