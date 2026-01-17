using System.ComponentModel.DataAnnotations;

namespace InventarApp.Models
{
    public class Proizvod
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Naziv je obavezan")]
        [StringLength(100, ErrorMessage = "Naziv može imati maksimalno 100 znakova")]
        public string Naziv { get; set; }
        
        [Required(ErrorMessage = "Cijena je obavezna")]
        [Range(0.01, 1000000, ErrorMessage = "Cijena mora biti između 0.01 i 1,000,000")]
        [Display(Name = "Cijena (€)")]
        public double Cijena { get; set; }
        
        [Required(ErrorMessage = "Količina je obavezna")]
        [Range(0, 100000, ErrorMessage = "Količina mora biti između 0 i 100,000")]
        public int Kolicina { get; set; }

        public double IzracunajUkupnuVrijednost()
        {
            return Cijena * Kolicina;
        }
    }
}