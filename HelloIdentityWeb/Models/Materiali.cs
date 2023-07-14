using System.ComponentModel.DataAnnotations;

namespace HelloIdentityWeb.Models
{
    public class Materiale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Descrizione { get; set; }
    }
}
