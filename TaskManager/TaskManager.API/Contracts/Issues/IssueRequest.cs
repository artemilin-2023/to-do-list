using System.ComponentModel.DataAnnotations;
using TaskManager.Domain;

namespace TaskManager.API.Contracts.Issues
{
    public record IssueRequest
    (
        [Required] string Description, 
        [Required] IssueStatus Status
    );
}
