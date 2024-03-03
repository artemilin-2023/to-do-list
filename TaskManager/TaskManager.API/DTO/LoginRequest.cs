using System.ComponentModel.DataAnnotations;

namespace TaskManager.API.DTO
{
    public record LoginRequest
    {
        [Required] public string Username { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Email { get; set; }
    }
}
