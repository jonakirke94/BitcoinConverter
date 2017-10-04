using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinConverter.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal DKKPrice { get; set; }
        public string ImgUrl { get; set; }
        public string BitcoinPrice { get; set; }
    }
}
