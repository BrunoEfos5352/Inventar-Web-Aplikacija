using Microsoft.AspNetCore.Mvc;
using InventarApp.Models;
using System.Linq;

namespace InventarApp.Controllers
{
    public class ProizvodController : Controller
    {
        private static List<Proizvod> _proizvodi = new List<Proizvod>
        {
            new Proizvod { Id = 1, Naziv = "Laptop", Cijena = 800, Kolicina = 5 }
        };

        public IActionResult Index() => View(_proizvodi);

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Proizvod novi)
        {
            if (ModelState.IsValid)
            {
                novi.Id = _proizvodi.Any() ? _proizvodi.Max(x => x.Id) + 1 : 1;
                _proizvodi.Add(novi);
                return RedirectToAction("Index");
            }
            return View(novi);
        }

        public IActionResult Edit(int id)
        {
            var p = _proizvodi.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Proizvod editirani)
        {
            if (id != editirani.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var stari = _proizvodi.FirstOrDefault(x => x.Id == id);
                if (stari != null)
                {
                    stari.Naziv = editirani.Naziv;
                    stari.Cijena = editirani.Cijena;
                    stari.Kolicina = editirani.Kolicina;
                }
                return RedirectToAction("Index");
            }
            return View(editirani);
        }

        public IActionResult Delete(int id)
        {
            var p = _proizvodi.FirstOrDefault(x => x.Id == id);
            if (p == null)
            {
                return NotFound();
            }
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var p = _proizvodi.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                _proizvodi.Remove(p);
            }
            return RedirectToAction("Index");
        }
    }
}