using AAClothing.DTO;
using AAClothing.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AAClothing.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Index() 
        {
            List<Winkelwagenmodel> products = HttpContext.Session.GetComplexData<List<Winkelwagenmodel>>("userCart");
            return PartialView("_Cart", products);
        }

        [HttpPost]
        public IActionResult Add()
        {

            StreamReader sr = new StreamReader(Request.Body);
            string data = sr.ReadToEnd();

            WinkelwagenDTO cpvm = Newtonsoft.Json.JsonConvert.DeserializeObject<WinkelwagenDTO>(data);

            List<Winkelwagenmodel> products = HttpContext.Session.GetComplexData<List<Winkelwagenmodel>>("userCart");

            if (products == null)
            {
                products = new List<Winkelwagenmodel>();
            }

            if (products.Where(x => x.Id == cpvm.ProductId).ToList().Count == 0)
            {

                Winkelwagenmodel cp = new Winkelwagenmodel
                { 
                    Id = cpvm.ProductId,
                    Naam = cpvm.ProductNaam,
                    Prijs = cpvm.ProductPrijs,
                    Totaalprijs = cpvm.TotalPrice,
                    Aantal = 1,

                };

                products.Add(cp);
            }
            else
            {
                products.FirstOrDefault(x => x.Id == cpvm.ProductId).Aantal += 1;
            }

            HttpContext.Session.SetComplexData("userCart", products);

            return Content(products.Sum(x => x.Aantal).ToString());
        }
    }
}
