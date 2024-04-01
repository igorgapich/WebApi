using Core.DTOs.User;
using Core.Helpers;
using Core.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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

        public async Task Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByNameAsync(loginDto.Username);
            var resultCreaditional = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (user == null || !resultCreaditional)
                throw new CustomHttpException(ErrorMessages.InvalidCreditional, HttpStatusCode.BadRequest);

                await _signInManager.SignInAsync(user, true);
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
