using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewProjectOnMVCFullStack.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required.")]
        public string? UserName { get; set; }
        [Required]
        [PasswordPropertyText]
        public string? Password { get; set; }

        [Required]
        [PasswordPropertyText]
        [Compare("Password",ErrorMessage ="Password is not same.")]
        public string? ConfirmPassword { get; set; }

        [Required(ErrorMessage ="Email address is required.")]
        [EmailAddress]
        public string? Email { get; set; }

    }
}
