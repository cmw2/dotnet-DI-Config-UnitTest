/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithDI.NonDIServices
{
    public class TaxCalculator
    {
        public decimal CalculateTax(decimal subtotal, string state)
        {
            var rateProvider = new TaxRateProvider();
            return Math.Round(subtotal * rateProvider.GetTaxRate(state), 2);
        }

    }
}
