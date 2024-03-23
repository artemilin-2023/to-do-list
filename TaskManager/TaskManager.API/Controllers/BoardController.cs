using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Contracts.Board;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/v1"), Authorize, ApiController]
    public class BoardController : ControllerBase
    {
        private readonly BoardServices boardServices;
        private readonly AccountServices accountServices;

        public BoardController(BoardServices boardServices, AccountServices accountServices)
        {
            this.boardServices = boardServices;
            this.accountServices = accountServices;
        }

        [HttpPost("/boards/")]
        public async Task<IResult> Create([FromBody] BoardRequest request)
        {
            if (WrongRequest(request))
                return Results.BadRequest();

            var userId = accountServices.GetUserId(HttpContext.Request.Cookies["meow"]!);
            await boardServices.CreateAsync(request.Title, userId);
            return Results.Ok();
        }

        private bool WrongRequest(BoardRequest request) =>
            request == null || request.Title == null;

        [HttpGet("/boards/{id}")]
        public async Task<IResult> Get(Guid id)
        {
            return Results.Ok(await boardServices.GetAsync(id));
        }

        [HttpGet("/boards/")]
        public IResult GetAll()
        {
            var result = boardServices.GetAll();
            return Results.Ok(result);
        }

        [HttpDelete("/boards/{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            var userId = accountServices.GetUserId(HttpContext.Request.Cookies["meow"]!);
            await boardServices.DeleteAsync(id, userId);
            return Results.Ok();
        }

        [HttpPut("/boards/{id}")]
        public async Task<IResult> Update(Guid id, [FromBody] string newTitle)
        {
            await boardServices.UpdateAsync(id, newTitle);
            return Results.Ok();
        }
    }
}
