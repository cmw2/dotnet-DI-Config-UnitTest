/* This Sample Code is provided for the purpose of illustration only 
 * and is not intended to be used in a production environment.   
 */

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Math.Tests
{
    [TestClass()]
    public class Math_AddShould
    {
        [TestMethod()]
        public void Add_SingleNumber_ReturnsSameNumber()
        {
            // Arrange
            var math = new Math();

            // Act
            int result = math.Add(1, 0);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod()]
        public void Add_SameNumberNegative_ReturnsZero()
        {
            // Arrange
            var math = new Math();

            // Act
            int result = math.Add(1, -1);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetPiTest()
        {
            Assert.Fail();
        }
    }
}