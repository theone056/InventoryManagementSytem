using InventoryManagementSystem.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Core.Models
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
