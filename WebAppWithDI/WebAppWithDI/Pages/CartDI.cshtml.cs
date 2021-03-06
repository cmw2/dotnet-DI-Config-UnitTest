/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace WebAppWithDI.Pages
{
    public class CartDIModel : PageModel
    {
        private readonly Services.IShoppingCart _cart;
        public CartDIModel(Services.IShoppingCart cart)
        {
            _cart = cart;
        }

        public Services.IShoppingCart Cart { get { return _cart; } }

        public void OnGet()
        {
            SetCartInfo();
        }

        private void SetCartInfo()
        {
            // Pretend we're reading from a cache or database or other source of current cart information
            var p = new Models.Product() { Name = "Prod1", Price = 5.59M };
            var p2 = new Models.Product() { Name = "Prod2", Price = 14.34M };
            Cart.AddItem(p, 2);
            Cart.AddItem(p2, 5);
            Cart.DeliveryState = "PA";
        }
    }
}
