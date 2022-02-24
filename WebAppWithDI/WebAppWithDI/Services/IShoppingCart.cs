/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithDI.Services
{
    public interface IShoppingCart
    {
        void SetContents(Models.Cart contents);

        string DeliveryState { get; set; }       

        List<Models.CartItem> Items { get; }

        void AddItem(Models.Product p, int q);

        public decimal SubTotal { get; }

        public decimal Tax { get; }

        public decimal Total { get; }
    }
}
