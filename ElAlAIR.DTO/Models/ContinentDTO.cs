using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DTO.Models
{
    public class ContinentDTO
    {
        public Guid ContinentId { get; set; }

        public string? ContinentName { get; set; } = null!;

        public string? Image { get; set; }

    }
}
