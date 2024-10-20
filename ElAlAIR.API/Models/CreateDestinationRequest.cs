namespace ElAlAIR.API.Models
{
    public class CreateDestinationRequest
    {
        public Guid DestinationId { get; set; }

        public Guid ContinentId { get; set; }

        public string? DepartureAirport { get; set; } = null!;

        public string? ReturnAirport { get; set; } = null!;

        public decimal? Price { get; set; }

        public string? CurrencyPayment { get; set; } = null!;

        public string? Name { get; set; } = null!;

        public string? Img { get; set; } = null!;
    }
}
