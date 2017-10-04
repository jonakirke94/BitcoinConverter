using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BitcoinConverter.BitcoinAPI
{
    public class Client
    {

        private static string BuildURL(string currency, string value)
        {
            return "https://blockchain.info/tobtc?currency=" + currency + "&value=" + value;
        }

        private static string MakeRequest(string link)
        {
            var client = new HttpClient();
            string responseString = "Unknown";

            //accepting json
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                var result = client.GetAsync(link).Result;
                var tmpresult = result.Content.ReadAsStringAsync().Result;
                var checkRes = JsonConvert.DeserializeObject<string>(tmpresult);

                if (!string.IsNullOrEmpty(checkRes))
                {
                    responseString = checkRes;
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine("Something went wrong in getrequest..: " + e.Message);
            }
            return responseString;
        }

        public double GetPrice(string currency, string value)
        {
            var url = BuildURL(currency, value);

            double unformattedBC = Double.Parse(MakeRequest(url), System.Globalization.CultureInfo.InvariantCulture);

            var formattedBC = BitcoinHelper.FormatBitcoin(unformattedBC);

            return formattedBC;
        }


    }
}
