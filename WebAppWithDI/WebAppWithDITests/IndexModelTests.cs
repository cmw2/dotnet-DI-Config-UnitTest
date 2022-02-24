/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebAppWithDI.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppWithDI.Services;
using Moq;

namespace WebAppWithDI.Pages.Tests
{
    [TestClass()]
    public class IndexModelTests
    {
        [TestMethod()]
        public void OnGetTest()
        {
            // Arrange
            decimal rate = 0.5M;
            ITaxRateProvider provider = new FakeTaxRateProvider(rate);
            ITaxCalculator calc = new TaxCalculator(provider);
            IShoppingCart cart = new ShoppingCart(calc);

            var pageModel = new CartDIModel(cart);

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(pageModel.Cart.Tax, pageModel.Cart.SubTotal * rate);

        }

        [TestMethod()]
        public void OnGetTestMocked()
        {
            // Arrange
            decimal rate = 0.5M;
            var mock = new Mock<ITaxRateProvider>();
            mock.Setup(x => x.GetTaxRate(It.IsAny<String>())).Returns(rate).Verifiable();            

            ITaxCalculator calc = new TaxCalculator(mock.Object);
            IShoppingCart cart = new ShoppingCart(calc);

            var pageModel = new CartDIModel(cart);

            // Act
            pageModel.OnGet();

            // Assert
            Assert.AreEqual(pageModel.Cart.Tax, pageModel.Cart.SubTotal * rate);
            mock.Verify();

        }

    }
}