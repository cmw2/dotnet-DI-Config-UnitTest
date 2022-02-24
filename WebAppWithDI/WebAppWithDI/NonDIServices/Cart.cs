/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppWithDI.NonDIServices
{
    public class Cart
    {
        private NonDIServices.TaxCalculator _taxCalc = new TaxCalculator();
        private string _deliveryState;

        public List<CartItem> Items { get; private set; } = new List<CartItem>();

        public void AddItem(Models.Product p, int q)
        {
            Items.Add(new CartItem() { Product = p, Quantity = q });
        }

        public string DeliveryState
        {
            get
            {
                return _deliveryState;
            }
            set
            {
                _deliveryState = value;
            }
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
