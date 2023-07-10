using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloEFCodeFirst.Models
{
    internal class Prodotto
    {
        // Perchè 'Id' l'ha generato sul db come PK e Identity e invece Prezzo l'ha fatto solo 'int'?
        // Esiste una convenzione su nomi; se i programmatore scrive 'ID' oppure 'Id', allora EF genera un campo PKJ e Identity
        // Però è meglio usare le Data Annotations

        [Key] // Genera PK e Identity
        public int Id { get; set; }

        [Required]
        [MaxLength(3)]
        public string Codice { get; set; }


        // Data Annotation
        [Required]
        [MaxLength(50)]
        public string Descrizione { get; set; } // Se metto string? => consenti valori nulli sul db


        public double Prezzo { get; set; }

        // Tripletta per definire una FK
        public int ID_Categoria { get; set; }
        [ForeignKey(nameof(ID_Categoria))]
        public Categoria Categoria { get; set; }
        // Ricordarsi di mettere il DbSet nel Context!!
    }
}
