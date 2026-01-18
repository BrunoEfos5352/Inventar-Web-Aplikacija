using Microsoft.AspNetCore.Mvc;
using InventarApp.Models;
using System.Linq;

namespace InventarApp.Controllers
{
    // Klasa kontrolera koja obrađuje CRUD operacije za proizvode (Proizvod)
    public class ProizvodController : Controller
    {
        // Statička lista koja pohranjuje sve proizvode u memoriji (podaci se gube kada se aplikacija restartuje)
        // Inicijalizirana s jednim zadanim proizvodom (Laptop)
        private static List<Proizvod> _proizvodi = new List<Proizvod>
        {
            new Proizvod { Id = 1, Naziv = "Laptop", Cijena = 800, Kolicina = 5 }
        };

        // Akcijska metoda koja prikazuje listu svih proizvoda
        public IActionResult Index() => View(_proizvodi); // Vraća Index pogled s listom proizvoda

        // Akcijska metoda koja prikazuje formu za stvaranje novog proizvoda (GET zahtjev)
        public IActionResult Create() => View(); // Vraća Create pogled s praznom formom

        // Akcijska metoda koja obrađuje slanje forme za stvaranje novog proizvoda (POST zahtjev)
        [HttpPost] // Specificira da ova metoda odgovara na POST zahtjeve
        [ValidateAntiForgeryToken] // Štiti od Cross-Site Request Forgery (CSRF) napada
        public IActionResult Create(Proizvod novi)
        {
            // Provjera jesu li sva validacijska pravila zadovoljena
            if (ModelState.IsValid)
            {
                // Generiranje novog ID-a: ako lista ima proizvode, uzmi najveći ID i dodaj 1, inače koristi 1
                novi.Id = _proizvodi.Any() ? _proizvodi.Max(x => x.Id) + 1 : 1;
                // Dodavanje novog proizvoda u listu
                _proizvodi.Add(novi);
                // Preusmjeravanje na Index stranicu kako bi se prikazala ažurirana lista
                return RedirectToAction("Index");
            }
            // Ako validacija nije uspjela, vrati Create pogled s podacima o proizvodu i porukama o greškama
            return View(novi);
        }

        // Akcijska metoda koja prikazuje formu za uređivanje postojećeg proizvoda (GET zahtjev)
        public IActionResult Edit(int id)
        {
            // Pronalaženje proizvoda s navedenim ID-om
            var p = _proizvodi.FirstOrDefault(x => x.Id == id);
            // Ako proizvod nije pronađen, vrati 404 Not Found odgovor
            if (p == null)
            {
                return NotFound();
            }
            // Vraćanje Edit pogleda s podacima pronađenog proizvoda
            return View(p);
        }

        // Akcijska metoda koja obrađuje slanje forme za uređivanje proizvoda (POST zahtjev)
        [HttpPost] // Specificira da ova metoda odgovara na POST zahtjeve
        [ValidateAntiForgeryToken] // Štiti od Cross-Site Request Forgery (CSRF) napada
        public IActionResult Edit(int id, Proizvod editirani)
        {
            // Provjera da se ID u URL-u podudara s ID-om u podacima forme
            if (id != editirani.Id)
            {
                // Ako se ID-evi ne podudaraju, vrati 404 Not Found odgovor
                return NotFound();
            }

            // Provjera jesu li sva validacijska pravila zadovoljena
            if (ModelState.IsValid)
            {
                // Pronalaženje postojećeg proizvoda u listi
                var stari = _proizvodi.FirstOrDefault(x => x.Id == id);
                // Ako proizvod postoji, ažuriraj njegova svojstva
                if (stari != null)
                {
                    // Ažuriranje naziva proizvoda
                    stari.Naziv = editirani.Naziv;
                    // Ažuriranje cijene proizvoda
                    stari.Cijena = editirani.Cijena;
                    // Ažuriranje količine proizvoda
                    stari.Kolicina = editirani.Kolicina;
                }
                // Preusmjeravanje na Index stranicu kako bi se prikazala ažurirana lista
                return RedirectToAction("Index");
            }
            // Ako validacija nije uspjela, vrati Edit pogled s podacima o proizvodu i porukama o greškama
            return View(editirani);
        }

        // Akcijska metoda koja prikazuje stranicu za potvrdu brisanja proizvoda (GET zahtjev)
        public IActionResult Delete(int id)
        {
            // Pronalaženje proizvoda s navedenim ID-om
            var p = _proizvodi.FirstOrDefault(x => x.Id == id);
            // Ako proizvod nije pronađen, vrati 404 Not Found odgovor
            if (p == null)
            {
                return NotFound();
            }
            // Vraćanje Delete pogleda s detaljima proizvoda za potvrdu
            return View(p);
        }

        // Akcijska metoda koja obrađuje stvarno brisanje proizvoda (POST zahtjev)
        [HttpPost, ActionName("Delete")] // Odgovara na POST zahtjeve ali se mapira na akcijski naziv "Delete"
        [ValidateAntiForgeryToken] // Štiti od Cross-Site Request Forgery (CSRF) napada
        public IActionResult DeleteConfirmed(int id)
        {
            // Pronalaženje proizvoda s navedenim ID-om
            var p = _proizvodi.FirstOrDefault(x => x.Id == id);
            // Ako proizvod postoji, ukloni ga iz liste
            if (p != null)
            {
                _proizvodi.Remove(p);
            }
            // Preusmjeravanje na Index stranicu kako bi se prikazala ažurirana lista
            return RedirectToAction("Index");
        }
    }
}