using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTO
{
    public record LoginRequest
    (
        [Required] string Email,
        [Required] string Password
    );
}
