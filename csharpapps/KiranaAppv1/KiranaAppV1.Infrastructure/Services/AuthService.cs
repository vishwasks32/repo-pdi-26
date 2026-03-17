using AutoMapper;
using KiranaAppV1.API.DTOs.Responses;
using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace KiranaAppV1.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;

    public AuthService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }
    public Task<UserResponseDTO> GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDTO> GetUserByUsernameAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsUserExistsAsync(string username)
    {
        throw new NotImplementedException();
    }

    public Task<UserResponseDTO> LoginAsync(UserRequestDTO userRequestDTO)
    {
        throw new NotImplementedException();
    }

    public async Task<IdentityResult> RegisterAsync(UserRequestDTO userRequest)
    {
        var user = new IdentityUser { UserName = userRequest.Username, Email= userRequest.Email};
        var result = await _userManager.CreateAsync(user, userRequest.Password);
        return result;
    }
}