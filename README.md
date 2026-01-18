# Inventar Web Aplikacija

## Opis projekta

Inventar Web Aplikacija je jednostavna web aplikacija razvijena u ASP.NET Core 8.0 (MVC) za upravljanje inventarom proizvoda.

## Funkcionalnosti

- **Pregled proizvoda**: Prikazuje listu svih proizvoda u inventaru
- **Dodavanje proizvoda**: Omogu?ava dodavanje novih proizvoda s nazivom, cijenom i koli?inom
- **Ure?ivanje proizvoda**: Omogu?ava izmjenu postojećih proizvoda
- **Brisanje proizvoda**: Omogućava uklanjanje proizvoda iz inventara
- **Validacija podataka**: Uklju?uje validaciju unosa za sve podatke o proizvodu
- **Izračun vrijednosti**: Automatski izra?unava ukupnu vrijednost proizvoda (cijena × količina)

## Tehnologije

- **.NET 8.0**: Najnovija verzija .NET platforme
- **ASP.NET Core MVC**: Framework za izradu web aplikacija
- **C#**: Programski jezik

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
- **Količina**: Dostupna koli?ina (0 - 100,000)

## Pokretanje aplikacije

1. Klonirajte repozitorij
2. Otvorite projekt u Visual Studio 2022 ili novijoj verziji
3. Pritisnite F5 ili pokrenite projekt
4. Aplikacija će se pokrenuti u browseru

## Autor

Anna Ageljić, Ivan Geto, Josip Baričić, Bruno Vig

## Licenca

Ovaj projekt je razvijen u edukacijske svrhe.
