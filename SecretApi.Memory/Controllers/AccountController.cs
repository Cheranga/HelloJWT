using Microsoft.AspNetCore.Mvc;
using SecretApi.Memory.DTO;
using SecretApi.Memory.Services;

namespace SecretApi.Memory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountService _accountService;

        public AccountController(AccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost]
        public IActionResult Post(UserCredentials credentials)
        {
            //
            // TODO: Perform validation
            //
            var token = _accountService.GetToken(credentials);
            return Ok(token);
        }
    }
}