using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.Models
{
    public class Winkelwagenmodel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public int Aantal { get; set; }
        public double Totaalprijs { get; set; }
    }
}
