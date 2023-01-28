using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserService.Infrastructure.Interfaces;
using UserService.Interface;

namespace UserService.API.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    IUserService _userService;

    public UsersController(IUserService userService)
    {
      _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
      return Ok(await _userService.GetUsers());
    }

    [HttpPost]
    public async Task<IActionResult> AddUser(NewUser newUser)
    {
      return Ok(await _userService.AddUser(newUser));
    }
  }
}
