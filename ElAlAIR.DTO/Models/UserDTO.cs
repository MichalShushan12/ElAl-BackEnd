using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DTO.Models
{
    public class UserDTO
    {
        public Guid UserId { get; set; }

        public string? UserName { get; set; } = null!;

        public string? Email { get; set; } = null!;

        public string? Password { get; set; } = null!;

        public DateTime? CreatedAt { get; set; }
    }
}
