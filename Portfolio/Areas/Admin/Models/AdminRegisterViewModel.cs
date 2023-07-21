using System.ComponentModel.DataAnnotations;

namespace Portfolio.Areas.Admin.Models
{
    public class AdminRegisterViewModel
    {
        public string Email { get; set; }
        public string Name { get; set; } = null!;
        public string Surname { get; set; }=null!;
        public string Username { get; set; }=null!;
        public string Password { get; set; }=null!;
        [Compare(nameof(Password), ErrorMessage ="Parolu duzgun daxil edin")]
        public string ConfirmPassword { get; set; }=null!;
        public string? ImageUrl { get; set; }
    }
}
