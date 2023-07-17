using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace CustomIdentity.Data
{
    public class CustomUser : IdentityUser
    {
        [Required(ErrorMessage ="{0} è obbligatorio!")]
        [MaxLength(100, ErrorMessage ="Massimo {1} caratteri!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(100, ErrorMessage = "Massimo {1} caratteri!")]
        public string Cognome { get; set; }
    }
}
