/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithDI.NonDIServices
{
    public class CartItem
    {
        public Models.Product Product { get; set; }
        public int Quantity { get; set; }

    }
}
