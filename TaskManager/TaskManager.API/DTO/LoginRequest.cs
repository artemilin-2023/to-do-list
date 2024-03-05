using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager.API.DTO
{
    public record LoginRequest
    (
        [Required] [NotNull] string Email,
        [Required] [NotNull] string Password
    );
}
