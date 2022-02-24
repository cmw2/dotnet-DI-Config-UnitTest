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

namespace WebAppWithConfig.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Services.Cart _cart;

        public IndexModel(ILogger<IndexModel> logger, Services.Cart cart)
        {
            _logger = logger;
            _cart = cart;
        }

        public Services.Cart Cart { get { return _cart; } }

        public void OnGet()
        {
            var p = new Models.Product() { Name = "Prod1", Price = 5.59M };
            var p2 = new Models.Product() { Name = "Prod2", Price = 14.34M };
            Cart.AddItem(p, 2);
            Cart.AddItem(p2, 5);
            Cart.SetDeliveryState("HI");            
        }
    }
}
