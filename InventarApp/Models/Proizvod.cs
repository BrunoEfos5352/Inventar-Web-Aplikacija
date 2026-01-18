using System.ComponentModel.DataAnnotations;

namespace InventarApp.Models
{
    // Definiranje javne klase koja predstavlja proizvod (Proizvod) u sustavu inventara
    public class Proizvod
    {
        // Jedinstveni identifikator za proizvod
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Naziv je obavezan")] // Atribut Required osigurava da ovo polje mora imati vrijednost
        [StringLength(100, ErrorMessage = "Naziv može imati maksimalno 100 znakova")] // Ograničava duljinu stringa na maksimalno 100 znakova
        public string Naziv { get; set; } // Svojstvo naziva proizvoda
        
        [Required(ErrorMessage = "Cijena je obavezna")] // Atribut Required osigurava da ovo polje mora imati vrijednost
        [Range(0.01, 1000000, ErrorMessage = "Cijena mora biti između 0.01 i 1,000,000")] // Osigurava da je cijena između 0.01 i 1,000,000
        [Display(Name = "Cijena (€)")] // Atribut Display postavlja tekst oznake prikazan u korisničkom sučelju
        public double Cijena { get; set; } // Svojstvo cijene proizvoda
        
        [Required(ErrorMessage = "Količina je obavezna")] // Atribut Required osigurava da ovo polje mora imati vrijednost
        [Range(0, 100000, ErrorMessage = "Količina mora biti između 0 i 100,000")] // Osigurava da je količina između 0 i 100,000
        public int Kolicina { get; set; } // Svojstvo količine proizvoda

        // Metoda za izračun ukupne vrijednosti ovog proizvoda u inventaru množenjem cijene s količinom
        public double IzracunajUkupnuVrijednost()
        {
            return Cijena * Kolicina; // Vraća rezultat množenja cijene s količinom
        }
    }
}