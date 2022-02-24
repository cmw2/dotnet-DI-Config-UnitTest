/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithConfig.Services
{
    public class TaxRateProviderOptions
    {
        public decimal DefaultRate { get; set; }
        public Dictionary<string, decimal> USStateRates { get; set; }
    }
}
