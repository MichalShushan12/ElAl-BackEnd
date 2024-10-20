using System;
using System.Collections.Generic;

namespace ElAlAIR.DataAccess.Entities;

public partial class Continent
{
    public Guid ContinentId { get; set; }

    public string? ContinentName { get; set; } = null!;

    public string? Image { get; set; }

    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();
}
