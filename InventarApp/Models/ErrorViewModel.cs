namespace InventarApp.Models
{
    // Klasa view modela za prikazivanje informacija o greškama korisnicima
    public class ErrorViewModel
    {
        // Pohranjuje jedinstveni ID zahtjeva za pra?enje (nullable string)
        public string? RequestId { get; set; }

        // Izra?unato svojstvo koje vra?a true ako RequestId nije null ili prazan, koristi se za uvjetno prikazivanje RequestId-a u prikazu greške
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
