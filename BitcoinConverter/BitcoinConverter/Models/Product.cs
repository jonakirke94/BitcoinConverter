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
        public decimal BitcoinPrice { get; set; }
        public decimal MikroPrice { get; set; }
        public decimal MilliPrice { get; set; }
        public decimal SatoPrice { get; set; }

    }
}
