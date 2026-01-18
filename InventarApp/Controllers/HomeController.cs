// Uvoz potrebnog namespace-a za dijagnostiku (pra?enje aktivnosti)
using System.Diagnostics;
// Uvoz namespace-a modela za korištenje view modela
using InventarApp.Models;
// Uvoz ASP.NET Core MVC namespace-a za funkcionalnost kontrolera
using Microsoft.AspNetCore.Mvc;

namespace InventarApp.Controllers
{
    // Klasa kontrolera koja obra?uje zahtjeve za po?etne stranice
    public class HomeController : Controller
    {
        // Privatno polje za pohranu instance logger-a za ovaj kontroler
        private readonly ILogger<HomeController> _logger;

        // Konstruktor koji prima instancu logger-a kroz dependency injection
        public HomeController(ILogger<HomeController> logger)
        {
            // Dodjela injektiranog logger-a privatnom polju
            _logger = logger;
        }

        // Akcijska metoda koja vra?a pogled po?etne stranice
        public IActionResult Index()
        {
            // Vra?anje Index pogleda korisniku
            return View();
        }

        // Akcijska metoda koja vra?a pogled stranice s politikom privatnosti
        public IActionResult Privacy()
        {
            // Vra?anje Privacy pogleda korisniku
            return View();
        }

        // Akcijska metoda koja prikazuje grešku s onemogu?enim cachiranjem
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)] // Sprje?avanje cachiranja stranica s greškama
        public IActionResult Error()
        {
            // Vra?anje Error pogleda s ErrorViewModel-om koji sadrži ID zahtjeva za pra?enje
            // Koristi Activity.Current.Id ako je dostupan, ina?e koristi HttpContext.TraceIdentifier
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
