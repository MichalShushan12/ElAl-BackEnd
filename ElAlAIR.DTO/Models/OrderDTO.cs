using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DTO.Models
{
    public class OrderDTO
    {
        public Guid OrderId { get; set; }

        public Guid UserId { get; set; }

        public DateTime? OrderDate { get; set; }

        public decimal? TotalAmount { get; set; }

        public string? PaymentStatus { get; set; } = null!;


    }
}
