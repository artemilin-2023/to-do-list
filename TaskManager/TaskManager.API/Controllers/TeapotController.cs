using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TaskManager.API.Controllers
{
    [Route("api/v1"), ApiController]
    public class TeapotController : Controller
    {
        [Authorize, HttpGet("/makecoffee/")]
        public IResult Index(string coffeeType)
        {
            if (coffeeType.IsNullOrEmpty())
                return Results.BadRequest($"{nameof(coffeeType)}Can`t be null");

            HttpContext.Response.StatusCode = 418;
            return Results.BadRequest("I`m a teapot!");
        }
    }
}
