# Inventar Web Aplikacija

## Opis projekta

Inventar Web Aplikacija je jednostavna web aplikacija razvijena u ASP.NET Core 8.0 (MVC) za upravljanje inventarom proizvoda.

## Funkcionalnosti

- **Pregled proizvoda**: Prikazuje listu svih proizvoda u inventaru
- **Dodavanje proizvoda**: Omogu?ava dodavanje novih proizvoda s nazivom, cijenom i koli?inom
- **Ure?ivanje proizvoda**: Omogu?ava izmjenu postoje?ih proizvoda
- **Brisanje proizvoda**: Omogu?ava uklanjanje proizvoda iz inventara
- **Validacija podataka**: Uklju?uje validaciju unosa za sve podatke o proizvodu
- **Izra?un vrijednosti**: Automatski izra?unava ukupnu vrijednost proizvoda (cijena × koli?ina)

## Tehnologije

- **.NET 8.0**: Najnovija verzija .NET platforme
- **ASP.NET Core MVC**: Framework za izradu web aplikacija
- **C#**: Programski jezik
- **Razor Views**: Templating engine za prikaz stranica

## Struktura projekta

```
InventarApp/
??? Controllers/          # Kontroleri za obradu zahtjeva
?   ??? HomeController.cs
?   ??? ProizvodController.cs
??? Models/              # Modeli podataka
?   ??? Proizvod.cs
?   ??? ErrorViewModel.cs
??? Views/               # Pogledi (UI)
??? Program.cs           # Glavna konfiguracijska datoteka
```

## Model proizvoda

Svaki proizvod sadrži:
- **Id**: Jedinstveni identifikator
- **Naziv**: Naziv proizvoda (max 100 znakova)
- **Cijena**: Cijena u eurima (€) (0.01 - 1,000,000)
- **Koli?ina**: Dostupna koli?ina (0 - 100,000)

## Pokretanje aplikacije

1. Klonirajte repozitorij
2. Otvorite projekt u Visual Studio 2022 ili novijoj verziji
3. Pritisnite F5 ili pokrenite projekt
4. Aplikacija ?e se pokrenuti u browseru

## Autor

Bruno Efos

## Licenca

Ovaj projekt je razvijen u edukacijske svrhe.