using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BibliotecaWeb.Models
{
    public class Libro
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(100)]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [Range(1, 200,ErrorMessage ="{0} deve stare fra {1} e {2} euro!")]
        public int Prezzo { get; set; }

        public int IdAutore { get; set; }
        [ForeignKey(nameof(IdAutore))]
        public Autore? Autore { get; set; }

        public int IdEditore { get; set; }
        [ForeignKey(nameof(IdEditore))]
        public Editore? Editore { get; set; }
    }
}
