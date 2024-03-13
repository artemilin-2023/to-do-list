using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.Contracts.Board
{
    public record BoardRequest
    (
        [Required] string Title,
        [Required] Guid UserId
    );
}
