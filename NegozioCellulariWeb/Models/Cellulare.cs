using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NegozioCellulariWeb.Models
{
    public enum TipoCellulare { Apple, Android }
    public class Cellulare
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="{0} è obbligatorio!")]
        [Display(Name ="Tipo cellulare")]
        public TipoCellulare Tipo { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [MaxLength(200, ErrorMessage ="Massimo {1} caratteri!")]
        public string Modello { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [Range(150, 2000, ErrorMessage ="{0} deve stare fra {1} e {2} euro!")]
        public int Prezzo { get; set; }

        [Required(ErrorMessage = "{0} è obbligatorio!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data acquisto")]
        public DateTime DataAcquisto { get; set; }

        // Voglio gestire un immagine per ogni cellulare
        [MaxLength(256)]
        [Display(Name = "Immagine")]
        public string? NomeImmagine { get; set; }

        [NotMapped]
        [Display(Name ="Immagine cellulare")] 
        public IFormFile? FileImmagine { get; set; }
    }
}
