/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace WebAppWithConfig.Services
{
    public class TaxRateProviderOptionsConfig : ITaxRateProvider
    {
        private TaxRateProviderOptions _options;

        public TaxRateProviderOptionsConfig(IOptions<TaxRateProviderOptions> options)
        {
            _options = options.Value;            
        }

        public decimal GetTaxRate(string state)
        {
            var rates = _options.USStateRates;
            decimal rate;
            if (!rates.TryGetValue(state, out rate))
            {
                rate = _options.DefaultRate;
            }

            return rate;
        }
    }
}
