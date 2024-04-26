using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace TaskManager.API.Controllers
{
    [ApiController]
    public class TeapotController : Controller
    {
        [Authorize, HttpGet("/api/v1/makecoffee/")]
        public IResult Index(string? coffeeType)
        {
            if (coffeeType.IsNullOrEmpty())
                return Results.BadRequest($"{nameof(coffeeType)} Can't be null");

            coffeeType = coffeeType!.ToLower();
            if (!coffeeType!.Contains("tea"))
            {
                HttpContext.Response.StatusCode = 418;
                return Results.BadRequest("I'm a teapot!");
            }
            
            if (coffeeType.Contains("black"))
                return Results.Ok("Your tea: ☕");
            return Results.Ok("Your tea: 🍵");
        }
    }
}
