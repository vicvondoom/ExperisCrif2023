using System.ComponentModel.DataAnnotations;

namespace NegozioMusicaWeb.Models
{
    public class Prodotto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(100)]
        public string Titolo { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(100)]
        public string Artista { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [Range(1945, 2045, ErrorMessage ="{0} deve stare fra {1} e {2}!")]
        [Display(Name ="Anno di uscita")]
        public int AnnoUscita { get; set; }
    }
}
