using System.ComponentModel.DataAnnotations;

namespace BibliotecaWeb.Models
{
    public class Autore
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} è obbligatorio!")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(100)]
        public string Cognome { get; set; }
    }
}
