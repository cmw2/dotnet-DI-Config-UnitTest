/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithConfig.Services
{
    public class Cart
    {
        private Services.ITaxCalculator _taxCalc;
        private string _deliveryState;

        public Cart(Services.ITaxCalculator taxCalc)
        {
            this._taxCalc = taxCalc;
            this.Items = new List<CartItem>();
        }

        public void SetDeliveryState(string state)
        {
            _deliveryState = state;
        }

        public List<CartItem> Items { get; private set; }

        public void AddItem(Models.Product p, int q)
        {
            Items.Add(new CartItem() { Product = p, Quantity = q });
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
                if (string.IsNullOrWhiteSpace(_deliveryState)) {
                    return 0M;
                } else {
                    return _taxCalc.CalculateTax(this.SubTotal, _deliveryState);
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
