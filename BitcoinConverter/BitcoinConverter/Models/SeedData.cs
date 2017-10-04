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
            P1.DKKPrice = 1450000.1378654m;
            P1.ImgUrl = "ferrari.jpg";

            P2.Name = "FERRARI 488";
            P2.DKKPrice = 1450000.01m;
            P2.ImgUrl = "ferrari.jpg";

            P3.Name = "FERRARI 488";
            P3.DKKPrice = 8.40m;
            P3.ImgUrl = "ferrari.jpg";

            P4.Name = "FERRARI 488";
            P4.DKKPrice = 1450000;
            P4.ImgUrl = "ferrari.jpg";

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
