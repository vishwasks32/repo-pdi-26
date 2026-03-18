using AutoMapper;
using KiranaAppV1.API.DTOs.Responses;
using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.Entities;
using KiranaAppV1.Core.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace KiranaAppV1.Infrastructure.Services;

public class AuthService : IAuthService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly ITokenService _tokenService;

    public AuthService(UserManager<IdentityUser> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
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

    public async Task<UserResponseDTO> LoginAsync(LoginRequestDTO loginRequest)
    {
        var user = await _userManager.FindByNameAsync(loginRequest.Username);

        if(user != null && await _userManager.CheckPasswordAsync(user, loginRequest.Password))
        {
            var roles = await _userManager.GetRolesAsync(user);
            var role = roles.FirstOrDefault<string>();
            var token = _tokenService.GenerateToken(user, roles);

            var userresponse = new UserResponseDTO(user.UserName,role,token);
            return  userresponse;
        }

        throw new UnauthorizedAccessException("Invalid Credentials");

    }

    public async Task<IdentityResult> RegisterAsync(UserRequestDTO userRequest)
    {
        if(userRequest.Role.ToString() == UserRole.Admin.ToString())
        {
            throw new UnauthorizedAccessException("Cannot Create an Admin User");
        }
        var user = new IdentityUser { UserName = userRequest.Username, Email= userRequest.Email};
        var result = await _userManager.CreateAsync(user, userRequest.Password);
        if (result.Succeeded)
        {

            await _userManager.AddToRoleAsync(user, userRequest.Role);
        }
        return result;
    }
}