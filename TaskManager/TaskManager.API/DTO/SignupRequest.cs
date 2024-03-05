using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager.API.DTO
{
    public record SignupRequest
    (
        [Required] [NotNull] string Username,
        [Required] [NotNull] string Password,
        [Required] [NotNull] string Email
    );
}
