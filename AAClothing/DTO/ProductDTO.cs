using AAClothing.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.DTO
{
    public class ProductDTO
    {
        public int ProductId { get;  set; }
        public string ProductNaam { get;  set; }
        public double ProductPrijs { get;  set; }
        public string ProductBeschrijving { get;  set; }
        public int ProductVoorraad { get;  set; }
        public byte[] ProductImage { get; set; }

        public ProductDTO ConvertToDTO(Productmodel p)
        {
            ProductId = p.Productid;
            ProductNaam = p.Productnaam;
            ProductPrijs = p.Productprijs;
            ProductImage = p.ProductImage;
            ProductVoorraad = p.ProductVoorraad;
            ProductBeschrijving = p.Productbeschrijving;

            return this;
        }
    }
}
