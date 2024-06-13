using System;

namespace PillPal
{
    public class Lekarz : User
    {
        public int IdLekarza { get; set; }
        public string PWZ { get; set; }
        public string Specjalizacja { get; set; }
        public string Miasto { get; set; }
    }
}