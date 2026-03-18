using Microsoft.AspNetCore.Mvc;

namespace randomuser;

[ApiController]
[Route("api/[controller]")]
public class UsersController: ControllerBase
{
    private readonly IRandomUserService _userService;

    public UsersController(IRandomUserService randomUserService)
    {
        _userService = randomUserService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var user = await _userService.GetRandomUserAsync();
        if(user == null) return NotFound();

        return Ok(user);
    }
}