/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithDI.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string ShippingState { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
