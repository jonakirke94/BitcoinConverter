using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinConverter.Models
{
    public class SeedData
    {
        public List<Product> Products { get; set; }
        public Product P1 = new Product();
        public Product P2 = new Product();
        public Product P3 { get; set; }
        public Product P4 { get; set; }
        public Product P5 { get; set; }
        public Product P6 { get; set; }

        public SeedData()
        {
            Products = new List<Product>();
            MakeData();
            AddProducts();
        }

        private void MakeData()
        {
            P1.Name = "1 Liter Mælk";
            P1.DKKPrice = 8.50m;
            P1.ImgUrl = "milk.jpg";

            P2.Name = "Bil";
            P2.DKKPrice = 500m;
            P2.ImgUrl = "~/images/milk.jpg";

        }
        

        private void AddProducts()
        {
            Products.Add(P1);
            Products.Add(P2);
            //Products.Add(P3);
            //Products.Add(P4);
            //Products.Add(P5);
            //Products.Add(P6);
        }

        
    }
}
