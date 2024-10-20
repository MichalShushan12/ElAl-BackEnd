using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElAlAIR.DTO.Models
{
    public class UpdatePasswordDTO
    {
        [Required]
        public string UserName { get; set; } // The user's name

        [Required]
        public string CurrentPassword { get; set; } // The current password for validation

        [Required]
        public string NewPassword { get; set; } // The new password to be set

        [Required]
        public string ConfirmNewPassword { get; set; }
    }
}
