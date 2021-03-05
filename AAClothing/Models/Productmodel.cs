using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.Models
{
    public class Productmodel
    {

        public int Productid { get; set; }
        public string Productnaam { get; set; }
        public double Productprijs { get; set; }
        public string Productbeschrijving { get; set; }
        public byte[] ProductImage { get; set; }

    }
}
