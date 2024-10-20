namespace ElAlAIR.API.Models
{
    public class CreateOrderRequest
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? PaymentStatus { get; set; } = null!;

    }
}
