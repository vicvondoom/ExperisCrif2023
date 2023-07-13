using System.ComponentModel.DataAnnotations;

namespace BibliotecaWeb.Models
{
    public class Editore
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(100)]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(100)]
        public string Sede { get; set; }
    }
}
