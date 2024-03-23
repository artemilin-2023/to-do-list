using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Contracts.Account;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/v1"), ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountServices accountServices;
        private const string CookieName = "meow";

        public AccountController(AccountServices accountServices)
        {
            this.accountServices = accountServices;
        }

        [HttpPost("/signup/")]
        public async Task<IResult> SignUp([FromBody] SignupRequest request)
        {
            if (request == null || request.Username == null || request.Email == null || request.Password == null)
                return Results.BadRequest();

            var token = await accountServices.Registr(request.Username, request.Email, request.Password);
            SetToken(token);

            return Results.Ok("sign up success");
        }

        private void SetToken(string token)
        {
            HttpContext.Response.Cookies.Append(CookieName, token);
        }

        [HttpPost("/login/")]
        public async Task<IResult> Login([FromBody] LoginRequest request)
        {
            if (request == null || request.Email == null || request.Password == null)
                return Results.BadRequest();

            var token = await accountServices.Login(request.Email, request.Password);
            SetToken(token);

            return Results.Ok("log in success");
        }

        [HttpGet("/logout")]
        public IResult Logout()
        {
            HttpContext.Response.Cookies.Delete(CookieName);
            return Results.Ok();
        }

        [HttpDelete("/account")]
        public async Task<IResult> Delete()
        {
            var userId = accountServices.GetUserId(HttpContext.Request.Cookies[CookieName]!);
            await accountServices.DeleteAccountAsync(userId);
            return Results.Ok();
        }
    }
}
