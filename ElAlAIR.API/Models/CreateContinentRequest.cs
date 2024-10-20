namespace ElAlAIR.API.Models
{
    public class CreateContinentRequest
    {
        public Guid ContinentId { get; set; }

        public string? ContinentName { get; set; } = null!;

        public string? Image { get; set; }

    }
}
