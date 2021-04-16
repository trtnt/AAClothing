using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.DTO
{
    public class WinkelwagenDTO
    {
        public int ProductId { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(255)]
        public string ProductNaam { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [StringLength(8000)]
        public string ProductDescription { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double ProductPrijs { get; set; }

        [Required]
        public byte[] ProductImage { get; set; }

        public double TotalPrice { get; set; }




        public WinkelwagenDTO ConvertToDTO(ProductDTO p)
        {
            ProductId = p.ProductId;
            ProductNaam = p.ProductNaam;
            ProductPrijs = p.ProductPrijs;
            ProductImage = p.ProductImage;

            return this;
        }
    }
}
