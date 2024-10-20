using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DTO.Models
{
    public class TokenDTO
    {
        public Guid TokenId { get; set; }

        public Guid UserId { get; set; }

        public string? TokenJwt { get; set; } = null!;

        public DateTime? ExpireDate { get; set; }
    }
}
