using System;
using System.Collections.Generic;

namespace ElAlAIR.DataAccess.Entities;

public partial class Destination
{
    public Guid DestinationId { get; set; }

    public Guid ContinentId { get; set; }

    public string? DepartureAirport { get; set; } = null!;

    public string? ReturnAirport { get; set; } = null!;

    public decimal? Price { get; set; }

    public string? CurrencyPayment { get; set; } = null!;

    public string? Name { get; set; } = null!;

    public string? Img { get; set; } = null!;

    public virtual Continent Continent { get; set; } = null!;
}
