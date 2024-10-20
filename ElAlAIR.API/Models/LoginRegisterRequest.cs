namespace ElAlAIR.API.Models
{
    public class LoginRegisterRequest
    {
        public Guid UserId { get; set; }

        public string? UserName { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}
