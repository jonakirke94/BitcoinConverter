using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BitcoinConverter.Models;
using BitcoinConverter.BitcoinAPI;

namespace BitcoinConverter.Controllers
{
    
    public class HomeController : Controller
    {
        private Client client = new Client();
        private string defeaultCurrency = "DKK";
        public IActionResult Index()
        {
            ProductViewModel model = new ProductViewModel
            {
                LastUpdated = DateTime.Now,
                Products = UpdateBitcoinPrices(),              
            };

            return View(model);
        }

        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private List<Product> UpdateBitcoinPrices()
        {
            SeedData data = new SeedData();
            List<Product> newList = new List<Product>(data.Products);

            


            foreach (Product item in newList)
            {
                item.BitcoinPrice = client.GetPrice(defeaultCurrency, item.DKKPrice) + " " + "\u0243";
            }

            return newList;
        }
    }
}
