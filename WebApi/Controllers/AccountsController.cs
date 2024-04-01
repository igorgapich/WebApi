using Core.DTOs.User;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountsController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("{id}")]
        public async Task <IActionResult> Get(string id)
        {
            return Ok(await _accountService.Get(id));
        }
        [HttpPost("registration")]
        public async Task<IActionResult> Registration(RegisterDto user)
        {
            await _accountService.Register(user);
            return Ok();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto user)
        {
            await _accountService.Login(user);
            return Ok();
        }
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _accountService.Logout();
            return Ok();
        }
    }
}
