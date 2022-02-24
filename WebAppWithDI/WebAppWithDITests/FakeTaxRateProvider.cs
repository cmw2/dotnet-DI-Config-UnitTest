/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithDI.Services
{
    public class FakeTaxRateProvider : ITaxRateProvider
    {
        private decimal _defaultRate;
        public FakeTaxRateProvider(decimal defaultRate)
        {
            _defaultRate = defaultRate;
        }

        public decimal GetTaxRate(string state)
        {
            return _defaultRate;
        }                
    }
}
