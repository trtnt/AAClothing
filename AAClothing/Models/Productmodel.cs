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
        public int ProductVoorraad { get; set; }
        public byte[] ProductImage { get; set; }

        public Productmodel (int productId, string productNaam, double productPrijs, int productVoorraad, byte[] productImage)
        {
            Productid = productId;
            Productnaam = productNaam;
            Productprijs = productPrijs;
            ProductVoorraad = productVoorraad;
            ProductImage = productImage;

        }

        public Productmodel(int productId)
        {
            Productid = productId;
        }

        public Productmodel()
        {

        }
    }
  
}
