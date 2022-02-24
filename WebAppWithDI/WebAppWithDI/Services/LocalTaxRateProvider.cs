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
    public class LocalTaxRateProvider : ITaxRateProvider
    {
        public decimal GetTaxRate(string state)
        {            
            decimal rate = 0.04M;
                        
            return rate;
        }

    }
}
