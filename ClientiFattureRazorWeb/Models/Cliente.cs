using System.ComponentModel.DataAnnotations;

namespace ClientiFattureRazorWeb.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Nome { get; set; }
    }
}
