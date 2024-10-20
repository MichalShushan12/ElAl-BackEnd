using System;
using System.Collections.Generic;

namespace ElAlAIR.DataAccess.Entities;

public partial class User
{
    public Guid UserId { get; set; }

    public string? UserName { get; set; } = null!;

    public string? Email { get; set; } = null!;

    public string? Password { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
