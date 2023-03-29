using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserAccess.BLL.Interfaces;
using UserAccess.BLL.Models;
using UserAccess.BLL.Models.Requests;
using UserAccess.BLL.Models.Responses;
using UserAccess.DAL.Entities;

namespace UserAccess.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserManager<User> _userManager;
    private readonly ITokenService _tokenService;
    private readonly IEmailService _emailService;

    public UserController(UserManager<User> userManager, ITokenService tokenService, IEmailService emailService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _emailService = emailService;
    }

    [HttpPost("Register")]
    public async Task<ActionResult<UserResponse>> Register([FromBody] UserRegisterModel model)
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

        var user = await _userManager.FindByNameAsync(model.UserName);

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink = Url.Action(nameof(ConfirmEmail), "User", new { token, email = user.Email }, Request.Scheme);

        await _emailService.SendEmailAsync(model.Email,
            "Behoof Email Confirmation",
            $"Click the link below to confirm email: \n{confirmationLink}");

        return Ok("Registration successful, please check your email for verification instructions");
    }

    [HttpPost("Login")]
    public async Task<ActionResult<UserResponse>> Login([FromBody] UserLoginModel userLoginModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var user = await _userManager.FindByNameAsync(userLoginModel.UserName);

        if (user == null)
        {
            return Unauthorized();
        }
        
        var result = await _userManager.CheckPasswordAsync(user, userLoginModel.Password);

        if (!result)
        {
            return Unauthorized();
        }

        return new UserResponse
        {
            Email = user.Email,
            UserName = user.UserName,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Token = _tokenService.CreateToken(user)
        };
    }

    [HttpGet("ConfirmEmail")]
    public async Task<IActionResult> ConfirmEmail(string token, string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return BadRequest("User does not exist");
        }

        var result = await _userManager.ConfirmEmailAsync(user, token);
        if (!result.Succeeded)
        {
            return BadRequest("Unable to confirm email");
        }

        return Ok("Email confirmed");
    }

    [HttpPost("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return BadRequest("User does not exist");
        }

        var passwordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
        var resetLink = Url.Action(nameof(PasswordReset), "User", new { passwordToken, email = user.Email }, Request.Scheme);
        
        await _emailService.SendEmailAsync(email,
            "Behoof Password Reset",
            $"Click the link to reset your password:\n{resetLink}");

        return Ok("Check your email to reset your password");
    }

    [HttpPost("PasswordReset")]
    public async Task<IActionResult> PasswordReset(ResetPasswordModel model)
    {
        var user = await _userManager.FindByEmailAsync(model.Email);

        if (user == null)
        {
            return BadRequest("User does not exist");
        }

        var resetResult = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
        
        if (!resetResult.Succeeded)
        {
            return BadRequest($"Unable to reset password.");
        }

        return Ok("Password reset successfully");

    }
}