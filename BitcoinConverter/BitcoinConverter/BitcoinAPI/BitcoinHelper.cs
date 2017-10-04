using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BitcoinConverter.BitcoinAPI
{
    public static class BitcoinHelper
    {
        // BITCOIN CONVERSIONS //
        //BITCENT = 0.01 bitcoin
        //MILLIBIT = 0.001 bitcoin
        //MICROBIT = 0.000001 bitcoin
        //SATOSHI = 0.00000001 bitcoin.

        public static string FormatBitcoin(decimal value)
        {
            //string stringValue = value.ToString();
            //string[] stringSplit = stringValue.Split(",");

            //string leftValue = stringSplit[0];

            string formatted = String.Format("Amount: {0:C}", value);

            return formatted;
        }

        
    }
}
