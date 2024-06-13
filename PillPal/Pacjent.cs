using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillPal
{
    public class Pacjent : User
    {
        public int IdPacjenta { get; set; }

        public Pacjent()
        {
            // Domyślny konstruktor
        }

        public Pacjent(int idPacjenta, string imie, string nazwisko, string pesel, DateTime dataUrodzenia, string plec)
        {
            IdPacjenta = idPacjenta;
            Imie = imie;
            Nazwisko = nazwisko;
            Pesel = pesel;
            DataUrodzenia = dataUrodzenia;
            Plec = plec;
        }
    }
}
