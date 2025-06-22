# EduZone - Platforma Korepetycyjna

EduZone to platforma e-commerce dedykowana sprzeda�y kurs�w i us�ug edukacyjnych online w architekturze mikroserwisowej.

## Opis projektu

Projekt sk�ada si� z kilku mikroserwis�w realizuj�cych kluczowe domeny platformy:

- **User.API** (port:8080)� rejestracja, logowanie, zarz�dzanie u�ytkownikami i rolami, autoryzacja JWT
- **Product.API** (port:8070)� zarz�dzanie kursami i kategoriami (CRUD, soft delete, cache)
- **Cart.API** (port:8060)(w przygotowaniu) � koszyk zakupowy z operacjami CRUD i procesowaniem
- **Order.API** (w przygotowaniu) � zarz�dzanie zam�wieniami i histori� zakup�w
- **Payment.API** (w przygotowaniu) � obs�uga p�atno�ci i integracje z systemami p�atniczymi
- **Invoice.API** (w przygotowaniu) � generowanie i wysy�ka faktur/paragon�w na email

## Kluczowe cechy

- Pe�na autoryzacja oparta o JWT, gdzie token generowany w User.API jest wykorzystywany przez pozosta�e mikroserwisy
- Rola **Admin** pozwala na zarz�dzanie zasobami
- Wst�pna implementacja cache (Redis) dla wydajnego pobierania kurs�w
- Soft delete z mo�liwo�ci� przywracania rekord�w 
- Ca�o�� uruchamiana za pomoc� **Docker Compose** � wszystkie mikroserwisy oraz zale�no�ci (bazy danych, Redis) dzia�aj� w kontenerach


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
2. **Przygotuj �rodowisko:** <br>
Przywr�� paczki NuGet - Visual Studio zazwyczaj robi to automatycznie przy otwieraniu projektu, lecz je�li nie:<br>
 -Tools > NuGet Package Manager > Restore NuGet Packages
3. **Uruchamon aplikacje:**<br>
    Aby uruchomi� aplikacj�, wybierz element startowy jako docker-compose (tr�jk�t przy przycisku z z�batk�) i kliknij przycisk Start (zielony przycisk prz Docker Compose) w Visual Studio lub naci�nij F5. 
    Aplikacja otworzy si� w Twojej domy�lnej przegl�darce internetowej.<br>
4. W User.API dost�pny jest seeder tworz�cy konto administratora:
   - **Username:** `admin`
   - **Password:** `password` <br>
5. Zaloguj si� w User.API (port:8080), odbierz token JWT.<br>
5. Wykorzystaj token JWT do autoryzacji w pozosta�ych serwisach (np. Product.API).<br>
6. W Swagger UI wpisz token w nag��wku `Authorization` w formacie:  
   `Bearer token` <br>

---

**EduZone** to elastyczna i skalowalna platforma edukacyjna oparta o nowoczesne mikroserwisy i technologie .NET.

