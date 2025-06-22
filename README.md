# EduZone - Platforma Korepetycyjna

EduZone to platforma e-commerce dedykowana sprzeda¿y kursów i us³ug edukacyjnych online w architekturze mikroserwisowej.

## Opis projektu

Projekt sk³ada siê z kilku mikroserwisów realizuj¹cych kluczowe domeny platformy:

- **User.API** (port:8080)– rejestracja, logowanie, zarz¹dzanie u¿ytkownikami i rolami, autoryzacja JWT
- **Product.API** (port:8070)– zarz¹dzanie kursami i kategoriami (CRUD, soft delete, cache)
- **Cart.API** (port:8060)(w przygotowaniu) – koszyk zakupowy z operacjami CRUD i procesowaniem
- **Order.API** (w przygotowaniu) – zarz¹dzanie zamówieniami i histori¹ zakupów
- **Payment.API** (w przygotowaniu) – obs³uga p³atnoœci i integracje z systemami p³atniczymi
- **Invoice.API** (w przygotowaniu) – generowanie i wysy³ka faktur/paragonów na email

## Kluczowe cechy

- Pe³na autoryzacja oparta o JWT, gdzie token generowany w User.API jest wykorzystywany przez pozosta³e mikroserwisy
- Rola **Admin** pozwala na zarz¹dzanie zasobami
- Wstêpna implementacja cache (Redis) dla wydajnego pobierania kursów
- Soft delete z mo¿liwoœci¹ przywracania rekordów 
- Ca³oœæ uruchamiana za pomoc¹ **Docker Compose** — wszystkie mikroserwisy oraz zale¿noœci (bazy danych, Redis) dzia³aj¹ w kontenerach


## Technologia

- .NET 8 / ASP.NET Core Web API
- Entity Framework Core (SQL Server)
- JWT Authentication & Authorization
- Redis (cache)
- Swagger / OpenAPI
- Docker & Docker Compose

## Uruchomienie
1. **Klonuj repozytorium:**
     ```bash
     git clone https://github.com/szym47/EduZone.git
     ```
2. **Przygotuj œrodowisko:** <br>
Przywróæ paczki NuGet - Visual Studio zazwyczaj robi to automatycznie przy otwieraniu projektu, lecz jeœli nie:<br>
 -Tools > NuGet Package Manager > Restore NuGet Packages
3. **Uruchamon aplikacje:**<br>
    Aby uruchomiæ aplikacjê, wybierz element startowy jako docker-compose (trójk¹t przy przycisku z zêbatk¹) i kliknij przycisk Start (zielony przycisk prz Docker Compose) w Visual Studio lub naciœnij F5. 
    Aplikacja otworzy siê w Twojej domyœlnej przegl¹darce internetowej.<br>
4. W User.API dostêpny jest seeder tworz¹cy konto administratora:
   - **Username:** `admin`
   - **Password:** `password` <br>
5. Zaloguj siê w User.API (port:8080), odbierz token JWT.<br>
5. Wykorzystaj token JWT do autoryzacji w pozosta³ych serwisach (np. Product.API).<br>
6. W Swagger UI wpisz token w nag³ówku `Authorization` w formacie:  
   `Bearer token` <br>

---

**EduZone** to elastyczna i skalowalna platforma edukacyjna oparta o nowoczesne mikroserwisy i technologie .NET.

