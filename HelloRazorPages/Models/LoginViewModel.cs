using System.ComponentModel.DataAnnotations;

namespace HelloRazorPages.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="{0} è obbligatoria!")]
        [EmailAddress(ErrorMessage ="Email non valida!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} è obbligatoria!")]
        [DataType(DataType.Password)] // Fà apparire i pallini invece che i caratteri
        public string Password { get; set; }
    }
}
