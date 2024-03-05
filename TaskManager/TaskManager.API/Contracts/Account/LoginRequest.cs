using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace TaskManager.API.Contracts.Account
{
    public record LoginRequest
    (
        [Required][NotNull] string Email,
        [Required][NotNull] string Password
    );
}
