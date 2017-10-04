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

        private static decimal MakeRequest(string link)
        {
            var client = new HttpClient();
            decimal responseString = 0.0m;

            //accepting json
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var result = client.GetAsync(link).Result;
                var tmpresult = result.Content.ReadAsStringAsync().Result;
                var checkRes = JsonConvert.DeserializeObject<decimal>(tmpresult);

                //if (!string.IsNullOrEmpty(checkRes))
                //{
                //    responseString = checkRes;
                //}
                responseString = checkRes;

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
            var leftResult = MakeRequest(leftUrl);
            decimal leftVal = Convert.ToDecimal(leftResult);

            var rightVal = 0.0m;

            if (1 < splitValue.Length)
            {
                var buildRightVal = "0." + splitValue[1];
                var unrounded = decimal.Parse(buildRightVal);
                var rounded = Math.Round(unrounded, 6);
                rightVal = rounded * OneMilliOreToBC();
            }

            decimal total = leftVal + rightVal;
            decimal totalRounded = Math.Round(total, 5);

            return totalRounded.ToString();
        }

        private decimal OneMilliOreToBC()
        {
            var url = BuildURL("DKK", "1");
            var stringResult = MakeRequest(url);
            //decimal result = decimal.Parse(stringResult);
            return stringResult / 1000000;
        }


    }
}
