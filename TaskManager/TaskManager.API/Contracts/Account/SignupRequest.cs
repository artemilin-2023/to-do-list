using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager.API.Contracts.Account
{
    public record SignupRequest
    (
        [Required][NotNull] string Username,
        [Required][NotNull] string Password,
        [Required][NotNull] string Email
    );
}
