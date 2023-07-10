using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEFCodeFirst.Models
{
    internal class Categoria
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descrizione { get; set; }
    }
}
