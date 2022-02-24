/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAppWithDI.NonDIServices
{
    public class TaxRateProvider
    {
        public decimal GetTaxRate(string state)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
            "https://cmwms-salestaxrates.azurewebsites.net/api/salestaxrate?state=" + state);
            var response = client.Send(request);

            decimal rate = 0.0M;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = response.Content.ReadAsStream();
                using var reader = new StreamReader(responseStream);
                rate = JsonSerializer.Deserialize<decimal>(reader.ReadToEnd());
            }

            return rate;
        }
    }
}
