
using KiranaAppV1.API.DTOs.Responses;
using KiranaAppV1.Core.DTOs.Requests;
using KiranaAppV1.Core.DTOs.Responses;
using KiranaAppV1.Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace  KiranaAppV1.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{

    private readonly IAuthService _authService;


    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] UserRequestDTO request)
    {
        var result = await _authService.RegisterAsync(request);
        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e=> e.Description).ToList();
            return BadRequest(new ApiResponse<object?>(false, "Registration Failed", null, errors));
        }

        // var response = new UserResponseDTO(request.Username, request.Role);

        return Ok(new ApiResponse<object?>(true, "Registration Sucessful", request.Username, []));
    }

        // [HttpPost("login")]
        // public async Task<IActionResult> Login([FromBody] UserRequest userRequest)
        // {
        //     var result = await _authService.LoginAsync(userRequest);
        //     if(result == null)
        //     {
        //         return Unauthorized(new ApiResponse<UserDto>(false, "Invalid Credentials", null));
        //     }
        //     return Ok(new ApiResponse<UserDto>(true, "Login Successful", result));
        // }

}