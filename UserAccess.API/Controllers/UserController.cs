﻿using Microsoft.AspNetCore.Identity;
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
    private readonly IEmailService _emailService;

    public UserController(UserManager<User> userManager, ITokenService tokenService, IEmailService emailService)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _emailService = emailService;
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
        
        var user = await _userManager.FindByNameAsync(model.UserName);

        var emailToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
        var confirmationLink = Url.Action(nameof(ConfirmEmail), "User", new { emailToken, email = user.Email }, Request.Scheme);

        await _emailService.SendEmailAsync(model.Email,
            "Behoof Email Confirmation",
            $"Click the link below to confirm email: \n{confirmationLink}");
        
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

    [HttpGet("EmailConfirmation")]
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


}