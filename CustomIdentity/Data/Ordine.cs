using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomIdentity.Data
{
    public class Ordine
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(100, ErrorMessage = "Massimo {1} caratteri!")]
        public string Descrizione { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [Range(1, 999)]
        public int Prezzo { get; set; }

        public string IdUser { get; set; }
        [ForeignKey(nameof(IdUser))]
        public CustomUser? User { get; set; }
    }
}
