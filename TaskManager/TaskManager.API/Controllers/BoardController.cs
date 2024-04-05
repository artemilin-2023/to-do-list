using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Contracts.Board;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [Authorize, ApiController]
    public class BoardController : ControllerBase
    {
        private readonly BoardServices boardServices;
        private readonly AccountServices accountServices;

        public BoardController(BoardServices boardServices, AccountServices accountServices)
        {
            this.boardServices = boardServices;
            this.accountServices = accountServices;
        }

        [HttpPost("/api/v1/boards/")]
        public async Task<IResult> Create([FromBody] BoardRequest request)
        {
            if (WrongRequest(request))
                return Results.BadRequest();

            var token = HttpContext.Request.Cookies["meow"]!;
            var userId = accountServices.GetUserId(token);
            await boardServices.CreateAsync(request.Title, userId);

            return Results.Ok();
        }

        private bool WrongRequest(BoardRequest request) =>
            request == null || request.Title == null;

        [HttpGet("/api/v1/boards/{id}")]
        public async Task<IResult> Get(Guid id)
        {
            return Results.Ok(await boardServices.GetAsync(id));
        }

        [HttpGet("/api/v1/boards/")]
        public IResult GetAll()
        {
            var result = boardServices.GetAll();
            return Results.Ok(result);
        }

        [HttpDelete("/api/v1/boards/{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            var token = HttpContext.Request.Cookies["meow"]!;
            var userId = accountServices.GetUserId(token);
            await boardServices.DeleteAsync(id, userId);

            return Results.Ok();
        }

        [HttpPut("/api/v1/boards/{id}")]
        public async Task<IResult> Update(Guid id, [FromBody] string newTitle)
        {
            var token = HttpContext.Request.Cookies["meow"]!;
            var userId = accountServices.GetUserId(token);
            await boardServices.UpdateAsync(id, userId, newTitle);

            return Results.Ok();
        }
    }
}
