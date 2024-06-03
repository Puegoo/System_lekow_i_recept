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
        public new string Pesel { get; set; } 

        public Pacjent()
        {
            // Domyślny konstruktor
        }
    }
}
