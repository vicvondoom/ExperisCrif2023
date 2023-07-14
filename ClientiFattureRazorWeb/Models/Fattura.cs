using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientiFattureRazorWeb.Models
{
    public class Fattura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Descrizione { get; set; }

        [Required]
        public DateTime DataFattura { get; set; }

        [Required]
        public int Importo { get; set; }

        public int IdCliente { get; set; }
        [ForeignKey(nameof(IdCliente))]
        public Cliente? Cliente { get; set; }
    }
}
