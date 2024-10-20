using System;
using System.Collections.Generic;

namespace ElAlAIR.DataAccess.Entities;

public partial class Order
{
    public Guid OrderId { get; set; }

    public Guid UserId { get; set; }

    public DateTime? OrderDate { get; set; }

    public decimal? TotalAmount { get; set; }

    public string? PaymentStatus { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
