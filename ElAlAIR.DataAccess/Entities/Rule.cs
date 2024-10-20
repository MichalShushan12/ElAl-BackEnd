using System;
using System.Collections.Generic;

namespace ElAlAIR.DataAccess.Entities;

public partial class Rule
{
    public Guid RuleId { get; set; }

    public string? RuleName { get; set; } = null!;
}
