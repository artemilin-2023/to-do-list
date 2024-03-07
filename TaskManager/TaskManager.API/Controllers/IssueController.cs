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

        public IssueController(IssueServices issueServices)
        {
            this.issueServices = issueServices;
        }

        [HttpGet("/boards/{boardId}/issues/")]
        public async Task<IResult> GetAll(Guid boardId)
        {
            return Results.Ok(issueServices.GetAll(boardId));
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

            await issueServices.CreateAsync(request.Description, request.Status, boardId);
            return Results.Ok();
        }

        private bool WrongRequest(IssueRequest request) => 
            request == null || request.Status == null || request.Description == null;

        [HttpPut("/boards/{boardId}/issues/{id}")]
        public async Task<IResult> Update(Guid boardId, Guid id, [FromBody] IssueRequest request)
        {
            if (WrongRequest(request))
                return Results.BadRequest();

            await issueServices.UpdateAsync(id, request.Description, request.Status);
            return Results.Ok();
        }

        [HttpDelete("/boards/{boardId}/issues/{id}")]
        public async Task<IResult> Delete(Guid boardId, Guid id)
        {
            await issueServices.DeleteAsync(id);
            return Results.Ok();
        }
    }
}
