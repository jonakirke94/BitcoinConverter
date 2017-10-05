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
        public Product P3 = new Product();
        public Product P4 = new Product();
        public Product P5 = new Product();
        public Product P6 = new Product();

        public SeedData()
        {
            Products = new List<Product>();
            MakeData();
            AddProducts();
        }

        private void MakeData()
        {
            P1.Name = "FERRARI 488";
            P1.DKKPrice = 1450000;
            P1.ImgUrl = "ferrari.jpg";

            P2.Name = "1 Liter Mælk";
            P2.DKKPrice = 10;
            P2.ImgUrl = "milk.jpg";

            P3.Name = "iPhone X 256GB";
            P3.DKKPrice = 10249;
            P3.ImgUrl = "iphoneX.jpg";

            P4.Name = "FCK Home Jersey 17/18";
            P4.DKKPrice = 699;
            P4.ImgUrl = "fck.jpg";

        }
        

        private void AddProducts()
        {
            Products.Add(P1);
            Products.Add(P2);
            Products.Add(P3);
            Products.Add(P4);
            //Products.Add(P5);
            //Products.Add(P6);
        }

        
    }
}
