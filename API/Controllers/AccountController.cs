using API.Repositories.Data;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        AccountRepository accountRepository;

        public AccountController(AccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }

        [HttpPost]
        public IActionResult Login(Login login)
        {
            var data = accountRepository.Login(login);
            if (data != null)
            {
                return Ok(new { message = "success login", statusCode = 200, data = data });
            }
            return BadRequest(new { message = "Failed login", statusCode = 200 });
        }
        [HttpPost("~/register")]
        public IActionResult RegisterAccount(RegisterAccount account)
        {
            var data = accountRepository.Register(account);
            if (data > 0)
            {
                return Ok(new { message = "success creating account !", statusCode = 201, data = data });
            }
            return BadRequest(new { message = "failed to create account", statusCode = 400 });
        }
        [HttpPost("~/changepassword")]
        public IActionResult ChangePassword(ChangePassword changePassword)
        {
            var data = accountRepository.ChangePassword(changePassword);
            if (data > 0)
            {
                return Ok(new { message = "success changing password !", statusCode = 201, data = data });
            }
            return BadRequest(new { message = "failed to change password", statusCode = 400 });
        }
    }
}
