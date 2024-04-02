using Core.DTOs.User;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountService(UserManager<IdentityUser> userManager, 
                              SignInManager<IdentityUser> signInManager,
                              IConfiguration configuration)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<IdentityUser> Get(string id)
        {
            var user = await _userManager.FindByNameAsync(id);
            if (user == null)
            {
                throw new CustomHttpException(ErrorMessages.UserNotFoundById, HttpStatusCode.NotFound);
            }
            return user;
        }

        public async Task<string> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            var resultCreaditional = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (user == null || !resultCreaditional)
                throw new CustomHttpException(ErrorMessages.InvalidCreditional, HttpStatusCode.BadRequest);

            await _signInManager.SignInAsync(user, true);

            //create Claim User

            var claimsParams = new List<Claim>() {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Name, user.UserName),
            };

            //generate JWT-Token

            var jwtOptions = _configuration.GetSection("Jwt").Get<JwtOptions>();

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokeOptions = new JwtSecurityToken(
                issuer: jwtOptions.Issuer,
                claims: claimsParams,
                expires: DateTime.Now.AddMinutes(jwtOptions.LifeTime),
                signingCredentials: signinCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

            return tokenString;
        }

        public async Task Logout()
        {//using signInManager
            await _signInManager.SignOutAsync();
        }

        public async Task Register(RegisterDto registerDto)
        {
            IdentityUser user = new()
            {
                UserName = registerDto.Username,
                Email = registerDto.Email
            };
            var resultCreated = await _userManager.CreateAsync(user, registerDto.Password);
            if (!resultCreated.Succeeded) {                
                string errorMessage = string.Join(", ", resultCreated.Errors.Select(er => er.Description));
                throw new CustomHttpException(errorMessage, HttpStatusCode.BadRequest);
            }
        }
    }
}
