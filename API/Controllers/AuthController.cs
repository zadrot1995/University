using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using University.Core.Commands;
using University.Core.Interfaces;
using University.Domain.Entities;

namespace University.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IEmailService _emailService;

        public AuthController(ITokenService tokenService, IEmailService emailService, UserManager<ApplicationUser> userManager)
        {
            _emailService = emailService;
            _tokenService = tokenService;
            _userManager = userManager;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command)
        {
            if (!command.Email.EndsWith("@nltu.edu.ua"))
                return BadRequest();
            if (!command.Password.Equals(command.PasswordConfirm))
                return BadRequest();

            var user = new ApplicationUser
            {
                UserName = command.Email,
                Email = command.Email
            };
            var result = await _userManager.CreateAsync(user, command.Password);
            if (result.Succeeded)
            {
                user.RefreshToken = _tokenService.GenerateRefreshToken();

                await _userManager.UpdateAsync(user);

                var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                var text = $"{token}";

                await _emailService.SendAsync(text, user.NormalizedEmail);

                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var user = await _userManager.FindByNameAsync(command.Email);
            if (user == null)
            {
                return BadRequest();
            }

            var isIdentical = await _userManager.CheckPasswordAsync(user, command.Password);
            if (!isIdentical)
            {
                return BadRequest();
            }

            if (!user.EmailConfirmed)
            {
                return Unauthorized();
            }

            user.RefreshToken = _tokenService.GenerateRefreshToken();
            await _userManager.UpdateAsync(user);
            var usersClaims = new[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id)
            };
            return Ok(new 
            {
                AccessToken = _tokenService.GenerateAccessToken(usersClaims),
                RefreshToken = user.RefreshToken
            });
        }

        [HttpGet]
        [Route("verify")]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return BadRequest();
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return BadRequest();
            }
            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (result.Succeeded)
                return Ok();
            else
                return BadRequest();
        }
    }
}
