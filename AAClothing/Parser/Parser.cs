using AAClothing.DTO;
using AAClothing.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.Parser
{
    public class Parser
    {
        public static ProductDTO DataSetToProduct(DataSet set, int rowIndex)
        {
            return new ProductDTO()
            {
                ProductId = (int)set.Tables[0].Rows[rowIndex][0],
                ProductNaam = (string)set.Tables[0].Rows[rowIndex][1],
                ProductBeschrijving = (string)set.Tables[0].Rows[rowIndex][2],
                ProductPrijs = (int)set.Tables[0].Rows[rowIndex][3],
                ProductVoorraad = (int)set.Tables[0].Rows[rowIndex][4],
                
            };
        }

        //public static KlantDTO DataSetToKlant(DataSet set, int rowIndex)
      //  {
        //    return new KlantDTO()
       //     {
         //       SpelerId = (int)set.Tables[0].Rows[rowIndex][0],
       //         Beloningen = (List<Klant>)set.Tables[0].Rows[rowIndex][1],
       //         MissieId = (int)set.Tables[0].Rows[rowIndex][2],
         //       Naam = (string)set.Tables[0].Rows[rowIndex][3]
         //   };
      //  }

    }
}
