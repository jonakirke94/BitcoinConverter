using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
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

        public string GetPrice(string currency, decimal value)
        {
            string[] splitValue = value.ToString().Split(",");

            var leftUrl = BuildURL(currency, splitValue[0]);
            string leftResult = MakeRequest(leftUrl);
            decimal leftVal = System.Convert.ToDecimal(leftResult);

            var rightVal = 0.0m;

            if (1 < splitValue.Length)
            {
                var buildRightVal = "0." + splitValue[1];
                rightVal = System.Convert.ToDecimal(buildRightVal) * OneOreToBC();
            }

            decimal total = leftVal + rightVal;

            return total.ToString();
        }

        private decimal OneOreToBC()
        {
            var url = BuildURL("DKK", "1");
            string stringResult = MakeRequest(url);
            Decimal result = Decimal.Parse(stringResult, CultureInfo.InvariantCulture);
            return result;
        }


    }
}
