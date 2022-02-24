/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace WebAppWithConfig.Services
{
    public class TaxRateProviderSimpleConfig : ITaxRateProvider
    {
        private IConfiguration _configuration;

        public TaxRateProviderSimpleConfig(IConfiguration configuration)
        {
            _configuration = configuration;            
        }

        public decimal GetTaxRate(string state)
        {
            var rates = _configuration.GetSection("TaxRates").Get<Dictionary<string, decimal>>();
            decimal rate;
            if (!rates.TryGetValue(state, out rate))
            {
                if (!rates.TryGetValue("Default", out rate))
                {
                    throw new ArgumentOutOfRangeException("state", "not a valid state identifier");
                }
            }

            return rate;
        }
    }
}
