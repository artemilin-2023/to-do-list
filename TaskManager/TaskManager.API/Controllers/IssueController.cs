using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Contracts.Issues;
using TaskManager.Application.Services;

namespace TaskManager.API.Controllers
{
    [Route("api/v1"), ApiController, Authorize]
    public class IssueController : ControllerBase
    {
        private readonly IssueServices issueServices;
        private readonly AccountServices accountServices;

        public IssueController(IssueServices issueServices, AccountServices accountServices)
        {
            this.issueServices = issueServices;
            this.accountServices = accountServices;
        }

        [HttpGet("/boards/{boardId}/issues/")]
        public async Task<IResult> GetAll(Guid boardId)
        {
            var result = await issueServices.GetAllAsync(boardId);
            return Results.Ok(result);
        }

        [HttpGet("/boards/{boardId}/issues/{id}")]
        public async Task<IResult> Get(Guid boardId, Guid id)
        {
            return Results.Ok(await issueServices.GetAsync(id));
        }

        [HttpPost("/boards/{boardId}/issues/")]
        public async Task<IResult> Create(Guid boardId, [FromBody] IssueRequest request)
        {
            if (WrongRequest(request))
                return Results.BadRequest();

            var token = HttpContext.Request.Cookies["meow"]!;
            var userId = accountServices.GetUserId(token);
            await issueServices.CreateAsync(boardId, userId, request.Description, request.Status);

            return Results.Ok();
        }

        private bool WrongRequest(IssueRequest request) => 
            request == null || request.Description == null;

        [HttpPut("/boards/{boardId}/issues/{id}")]
        public async Task<IResult> Update(Guid boardId, Guid id, [FromBody] IssueRequest request)
        {
            if (WrongRequest(request))
                return Results.BadRequest();

            var token = HttpContext.Request.Cookies["meow"]!;
            var userId = accountServices.GetUserId(token);
            await issueServices.UpdateAsync(id, boardId, userId, request.Description, request.Status);

            return Results.Ok();
        }

        [HttpDelete("/boards/{boardId}/issues/{id}")]
        public async Task<IResult> Delete(Guid boardId, Guid id)
        {
            var token = HttpContext.Request.Cookies["meow"]!;
            var userId = accountServices.GetUserId(token);
            await issueServices.DeleteAsync(id, boardId, userId);

            return Results.Ok();
        }
    }
}
