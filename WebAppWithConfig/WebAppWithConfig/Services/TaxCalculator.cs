/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithConfig.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private ITaxRateProvider _rateProvider;

        public TaxCalculator(ITaxRateProvider rateProvider)
        {
            _rateProvider = rateProvider;
        }

        public decimal CalculateTax(decimal subtotal, string state)
        {
            return Math.Round(subtotal * _rateProvider.GetTaxRate(state), 2);
        }

    }
}
