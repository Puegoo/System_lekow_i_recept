<h1 align="center">PillPal</h1>

<div align="center">
  <img src="Docs/PillPal_banner.png" width="100%" alt="Baner">
</div>

## Spis treści
1. [Opis założeń projektu](#opis-założeń-projektu)
2. [Funkcje systemu](#funkcje-systemu)
3. [Funkcje bazy danych](#funkcje-bazy-danych)
4. [Baza danych](#baza-danych)
5. [Przykładowe dane](#przykładowe-dane)
6. [Galeria](#galeria)
7. [Autorzy](#autorzy)

---

## Opis założeń projektu

Naszym celem jest stworzenie kompleksowego systemu wspierającego zarządzanie lekami, receptami oraz danymi pacjentów. Projekt ten ma na celu ułatwienie interakcji między pacjentami, lekarzami i farmaceutami, poprzez stworzenie internetowej platformy, która umożliwi łatwe zarządzanie informacjami dotyczącymi leczenia.

---

## Funkcje systemu

- **Logowanie i uwierzytelnianie**  
  Funkcja ta umożliwia użytkownikom logowanie się do systemu poprzez indywidualne konta.

- **Zarządzanie danymi pacjentów**  
  Pacjenci mogą zarejestrować się w systemie, przeglądać swoje dane osobowe oraz historię recept.

- **Wystawianie recept**  
  Lekarze mogą wystawiać recepty dla pacjentów, określając potrzebne leki oraz ich ilość.

- **Zarządzanie lekami**  
  Farmaceuci mogą dodawać informacje o dostępnych lekach w swojej aptece, wraz z ich ilością i ceną.

- **Zarządzanie aptekami**  
  Informacje o aptekach, takie jak nazwa, lokalizacja (miasto, ulica, numer) oraz asortyment leków, są przechowywane w systemie.

- **Śledzenie statusu recept**  
  Pacjenci mogą śledzić status swoich recept — czy są zrealizowane lub oczekują na realizację w aptece.

---

## Funkcje bazy danych

- **Zarządzanie receptami**  
  Procedury PL/SQL do dodawania, aktualizowania i usuwania recept oraz leków na receptach.

- **Zarządzanie asortymentem**  
  Procedury PL/SQL do dodawania i aktualizowania stanu magazynowego leków w aptekach.

- **Bezpieczeństwo**  
  Funkcje PL/SQL do walidacji danych, generowania unikalnych kodów recept oraz sprawdzania unikalności PESEL.

---

## Baza danych

**Diagram ERD**  
<div style="text-align:center; margin-bottom:24px;">
  <img src="Docs/Baza.png" alt="Diagram ERD" width="600">
</div>

---

## Przykładowe dane

- **Pacjent**  
  Login: `piotr`  
  Hasło: `zaq1@WSX`

- **Lekarz**  
  Login: `lekarz1` (od 1 do 9)  
  Hasło: `zaq1@WSX`

- **Farmaceuta**  
  Login: `farm1` (także 2, 3)  
  Hasło: `zaq1@WSX`

- **Baza danych**  
  Login: `hr`  
  Hasło: `oracle`

---

## Galeria

### Strona główna

<div align="center">
  <img src="Docs/strona_glowna.png" width="100%" alt="Strona główna">
</div>

---

### Logowanie

<table>
  <tr>
    <td align="center">
      <img src="Docs/log_pac.png" width="90%"><br>Logowanie pacjenta
    </td>
    <td align="center">
      <img src="Docs/log_lek.png" width="90%"><br>Logowanie lekarza
    </td>
  </tr>
  <tr>
    <td colspan="2" align="center">
      <img src="Docs/log_far.png" width="45%"><br>Logowanie farmaceuty
    </td>
  </tr>
</table>

---

### Pacjent

<table>
  <tr>
    <td align="center">
      <img src="Docs/panel_pac.png" width="90%"><br>Panel pacjenta
    </td>
    <td align="center">
      <img src="Docs/panel_pac_lek.png" width="90%"><br>Leki pacjenta
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Docs/panel_pac_edyt.png" width="90%"><br>Edycja danych
    </td>
    <td align="center">
      <img src="Docs/panel_pac_rec.png" width="90%"><br>Recepty pacjenta
    </td>
  </tr>
</table>

---

### Lekarz

<table>
  <tr>
    <td align="center">
      <img src="Docs/panel_lek.png" width="90%"><br>Panel lekarza
    </td>
    <td align="center">
      <img src="Docs/panel_lek_rec.png" width="90%"><br>Recepty lekarza
    </td>
  </tr>
  <tr>
    <td colspan="2" align="center">
      <img src="Docs/panel_lek_pac.png" width="45%"><br>Pacjenci lekarza
    </td>
  </tr>
</table>

---

### Farmaceuta

<table>
  <tr>
    <td align="center">
      <img src="Docs/panel_far.png" width="90%"><br>Panel farmaceuty
    </td>
    <td align="center">
      <img src="Docs/panel_far_rec_szcz.png" width="90%"><br>Szczegóły recepty
    </td>
  </tr>
  <tr>
    <td align="center">
      <img src="Docs/panel_far_aso.png" width="90%"><br>Asortyment apteki
    </td>
    <td align="center">
      <img src="Docs/panel_far_mag.png" width="90%"><br>Magazyn apteki
    </td>
  </tr>
  <tr>
    <td colspan="2" align="center">
      <img src="Docs/panel_far_rec.png" width="45%"><br>Recepty w aptece
    </td>
  </tr>
</table>


## Autorzy

- Piotr Nowak ([GitHub](https://github.com/Puegoo))
