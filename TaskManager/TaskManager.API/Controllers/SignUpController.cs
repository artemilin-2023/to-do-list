using Microsoft.AspNetCore.Mvc;
using TaskManager.API.DTO;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{

    [Route("api/v1")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly AccountServices accountServices;

        public SignUpController(AccountServices accountServices)
        {
            this.accountServices = accountServices;
        }

        [HttpPost("/signup/")]
        public IActionResult SignUp([FromBody] LoginRequest request)
        {
            if (request == null || request.Username == null || request.Email == null || request.Password == null)
                return BadRequest();

            throw new NotImplementedException();
        }
    }
}
