using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels.Authentication
{
    public class AccountRegistrationDTO
    {
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string AccountUserName { get; set; } = null!;

        public string? AccountFullName { get; set; }

        [Required]
        [EmailAddress]
        public string AccountEmail { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 6)]
        public string AccountPassword { get; set; } = null!;

        [Phone]
        public string AccountPhoneNumber { get; set; }

        public string Address { get; set; }

        [Required]
        public string AccountRole { get; set; } = "Member";

        public bool AccountIsExternal { get; set; } = false;
        public string? AccountExternalProvider { get; set; }
    }
}
