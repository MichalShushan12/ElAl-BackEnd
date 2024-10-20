using System;
using System.Collections.Generic;

namespace ElAlAIR.DataAccess.Entities;

public partial class Token
{
    public Guid TokenId { get; set; }

    public Guid UserId { get; set; }

    public string TokenJwt { get; set; } = null!;

    public DateTime ExpireDate { get; set; }

    public virtual User User { get; set; } = null!;
}
