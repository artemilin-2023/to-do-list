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

        public BoardController(BoardServices boardServices)
        {
            this.boardServices = boardServices;
        }

        [HttpPost("/boards/")]
        public async Task<IResult> Create([FromBody] BoardRequest request)
        {
            if (WrongRequest(request))
                return Results.BadRequest();

            await boardServices.CreateAsync(request.Title, request.UserId);
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
            return Results.Ok(boardServices.GetAllAsync());
        }

        [HttpDelete("/boards/{id}")]
        public async Task<IResult> Delete(Guid id)
        {
            await boardServices.DeleteAsync(id);
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
