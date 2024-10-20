using ElAlAIR.DTO.Models;

namespace ElAlAIR.API.Models
{
    public class CreateUserRequest
    {
        public Guid UserId { get; set; }

        public string? UserName { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }

    }
}
