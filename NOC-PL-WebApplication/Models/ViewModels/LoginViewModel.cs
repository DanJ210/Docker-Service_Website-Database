using System.ComponentModel.DataAnnotations;

namespace NOCPLWebApplication.Models.ViewModels {
    public class LoginViewModel {
        [Required]
        public string Username { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Rememeber Me")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
    }
}
