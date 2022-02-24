/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithDI.Services
{
    public class ShoppingCart : IShoppingCart
    {
        private Services.ITaxCalculator _taxCalc;
        private Models.Cart _contents = new Models.Cart() { Items = new List<Models.CartItem>()};

        public ShoppingCart(Services.ITaxCalculator taxCalc)
        {
            this._taxCalc = taxCalc;
        }

        public void SetContents(Models.Cart contents)
        {
            _contents = contents;
        }

        public string DeliveryState
        {
            get { return _contents?.ShippingState; }
            set { _contents.ShippingState = value; }
        }

        public List<Models.CartItem> Items { get { return _contents.Items; } }

        public void AddItem(Models.Product p, int q)
        {
            _contents.Items.Add(new Models.CartItem() { Product = p, Quantity = q });

        }

        public decimal SubTotal
        {
            get
            {
                return Math.Round(Items.Sum(i => i.Product.Price * i.Quantity), 2);
            }
        }

        public decimal Tax
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DeliveryState))
                {
                    return 0M;
                }
                else
                {
                    return _taxCalc.CalculateTax(this.SubTotal, DeliveryState);
                }
            }
        }

        public decimal Total
        {
            get
            {
                return this.SubTotal + this.Tax;
            }
        }

    }
}
