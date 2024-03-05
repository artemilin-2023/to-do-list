using Microsoft.AspNetCore.Mvc;
using TaskManager.API.DTO;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/v1"), ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountServices accountServices;

        public AccountController(AccountServices accountServices)
        {
            this.accountServices = accountServices;
        }

        [HttpPost("/signup/")]
        public async Task<IResult> SignUp([FromBody] SignupRequest request)
        {
            if (request == null || request.Username == null || request.Email == null || request.Password == null)
                return Results.BadRequest();

            await accountServices.Registr(request.Username, request.Email, request.Password);
            await accountServices.Login(request.Email, request.Password);

            return Results.Ok("sign up success");
        }

        [HttpPost("/login/")]
        public async Task<IResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || request.Email == null || request.Password == null)
                return Results.BadRequest();

            var token = await accountServices.Login(request.Email, request.Password);
            HttpContext.Response.Cookies.Append("meow", token);

            return Results.Ok("log in success");
        }
    }
}
