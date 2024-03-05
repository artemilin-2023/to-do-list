using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/v1"), ApiController, Authorize]
    public class IssueController : ControllerBase
    {
        private readonly IssueServices issueServices;


        [HttpGet("/boards/{boardId}/issues/")]
        public async Task<IResult> GetAll(Guid boardId)
        {
            return Results.Ok();
        }

        [HttpGet("/boards/{boardId}/issues/{id}")]
        public async Task<IResult> Get(Guid boardId, Guid id)
        {
            return Results.Ok();
        }

        [HttpPost("/boards/{boardId}/issues/")]
        public async Task<IResult> Create(Guid boardId)
        {
            return Results.Ok();
        }

        [HttpPut("/boards/{boardId}/issues/{id}")]
        public async Task<IResult> Update(Guid boardId, Guid id)
        {
            return Results.Ok();
        }

        [HttpDelete("/boards/{boardId}/issues/{id}")]
        public async Task<IResult> Delete(Guid boardId, Guid id)
        {
            return Results.Ok();
        }
    }
}
