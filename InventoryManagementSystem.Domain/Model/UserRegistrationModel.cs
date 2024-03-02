using InventoryManagementSystem.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagementSystem.Domain.Models
{
    public class UserRegistrationModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        [Required]
        public string? UserName { get; set; }
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        public UserRoles UserRole { get; set; }
    }
}
