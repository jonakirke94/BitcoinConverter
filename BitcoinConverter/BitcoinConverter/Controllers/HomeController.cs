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
                LastUpdated = DateTime.Now.ToString("dd. MMM HH:mm"),
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
            var rnd = new Random();
            SeedData data = new SeedData();
            List<Product> newList = new List<Product>(data.Products.OrderBy(item => rnd.Next())); //shuffles the list




            foreach (Product item in newList)
            {
                decimal btcPrice = client.GetPrice(defeaultCurrency, item.DKKPrice);
                decimal btcRounded = Math.Round(btcPrice, 5);
                item.BitcoinPrice = btcRounded;

                item.MikroPrice = Math.Round((btcPrice * 1000), 2);
                item.MilliPrice = Math.Round(btcPrice * 100000, 2);
                item.SatoPrice = Math.Round(btcPrice * 100000000, 2);

                






            }

            return newList;
        }

        

        

    }
}
