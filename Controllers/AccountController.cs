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
        //public IActionResult Register(Login login)
        //{
        //    var data = accountRepository.Login(login);
        //    if (data != null)
        //    {
        //        return Ok(new { message = "success login", statusCode = 200, data = data });
        //    }
        //    return BadRequest(new { message = "Failed login", statusCode = 200 });
        //}
    }
}
