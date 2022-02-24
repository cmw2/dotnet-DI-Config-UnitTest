/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebAppWithDI.Services
{
    public class TaxRateProvider : ITaxRateProvider
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        public TaxRateProvider(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }

        public decimal GetTaxRate(string state)
        {
            var client = _clientFactory.CreateClient();
            var uriBuilder = new UriBuilder(_config["TaxRateUri"]);
            uriBuilder.Path = "api/salestaxrate";
            uriBuilder.Query = "state=" + state;

            var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
            var response = client.Send(request);

            decimal rate = 0.0M;
            if (response.IsSuccessStatusCode)
            {
                using var responseStream = response.Content.ReadAsStream();
                using var reader = new StreamReader(responseStream);
                rate = JsonSerializer.Deserialize<Decimal>(reader.ReadToEnd());                
            }
            
            return rate;
        }

    }
}
