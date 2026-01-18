// Stvaranje graditelja web aplikacije koji ?e konfigurirati postavke i servise aplikacije
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Registracija MVC kontrolera i servisa za prikazivanje pogleda u dependency injection kontejner
builder.Services.AddControllersWithViews();

// Izgradnja web aplikacije iz konfiguriranog graditelja
var app = builder.Build();

// Configure the HTTP request pipeline.
// Provjera da li aplikacija NIJE pokrenuta u razvojnom okruženju
if (!app.Environment.IsDevelopment())
{
    // Korištenje middleware-a za obradu iznimki za preusmjeravanje grešaka na /Home/Error stranicu u produkciji
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    // Omogu?avanje HTTP Strict Transport Security (HSTS) za forsiranje HTTPS veza na 30 dana
    app.UseHsts();
}

// Preusmjeravanje svih HTTP zahtjeva na HTTPS za sigurnu komunikaciju
app.UseHttpsRedirection();
// Omogu?avanje posluživanja stati?kih datoteka (CSS, JavaScript, slike) iz wwwroot mape
app.UseStaticFiles();

// Omogu?avanje middleware-a za usmjeravanje kako bi se ulazni HTTP zahtjevi mapirali na krajnje to?ke
app.UseRouting();

// Omogu?avanje middleware-a za autorizaciju kako bi se provjerilo ima li korisnik dozvolu za pristup resursima
app.UseAuthorization();

// Mapiranje zadanog uzorka rute za MVC kontrolere
// Zadani kontroler je "Proizvod", zadana akcija je "Index", a id parametar je opcionalan
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Proizvod}/{action=Index}/{id?}");

// Pokretanje web aplikacije i po?etak slušanja HTTP zahtjeva
app.Run();
