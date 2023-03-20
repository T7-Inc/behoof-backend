using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserAccess.BLL.Interfaces;
using UserAccess.BLL.Models;
using UserAccess.DAL.Entities;

namespace UserAccess.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;

    public UserController(UserManager<User> userManager, ITokenService tokenService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
    }
    
    [HttpPost("Register")]
    public async Task<ActionResult<User>> PostUser([FromBody] UserRegisterModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var result = await _userManager.CreateAsync(
            new User()
            {
                UserName = model.UserName,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Currency = model.Currency,
                Country = model.Country
            }, model.Password);
        
        if (!result.Succeeded)
        {
            return BadRequest(result.Errors);
        }
        
        //TODO: Send Email verification
        
        return Ok("Registration successful, please check your email for verification instructions");
    }

    [HttpPost("Login")]
    public async Task<ActionResult<User>> Authentication([FromBody] UserLoginModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByNameAsync(model.UserName);

        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var token = _tokenService.CreateToken(user);
            return Ok(token);
        }

        return Unauthorized();
    }

}