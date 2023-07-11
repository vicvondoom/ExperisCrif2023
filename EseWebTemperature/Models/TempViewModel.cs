using System.ComponentModel.DataAnnotations;

namespace EseWebTemperature.Models
{
    public class TempViewModel
    {
        [Required]
        public decimal Celsius { get; set; }
    }
}
