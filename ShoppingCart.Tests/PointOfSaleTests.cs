using ShoppingCart.Exceptions;
using Xunit;

namespace ShoppingCart.Tests
{
    public class PointofSaleTests
    {
        public static TheoryData<string, decimal> shoppingCartItemTestData = new()
        {
            { "ABCDABAA", 32.4M },
            { "ABCDABAA", 32.4M },
            { "CCCCCCC", 7.25M },
            { "ABCD", 15.40M },
            { "AAAA", 7 },
            { "AAAAAAAA", 14 },
            { "CCCCCC", 6 },
            { "CCCCCCCCCCCCCCAAAAAAAA", 28.50M },
            { "BDBD", 24.30M },
            { string.Empty, 0 }
        };

        /// <summary>
        /// Test case for success 
        /// </summary>
        [Theory]
        [MemberData(nameof(shoppingCartItemTestData))]
        public void TotalCostTest(string shoppingCartItems, decimal expectedTotalCost)
        {
            // class to be tested
            var pointOfSale = new PointOfSale();

            pointOfSale.Scan(shoppingCartItems);
            var actualCost = pointOfSale.Total();

            Assert.Equal(expectedTotalCost, actualCost);
        }

        /// <summary>
        /// Test for failure
        /// </summary>
        [Fact]
        public void TotalCostWhenUnknownProductTest()
        {
            // class to be tested
            var pointOfSale = new PointOfSale();

            pointOfSale.Scan("ABCDEDFDF");

            Assert.Throws<ProductNotExistException>(() => pointOfSale.Total());
        }
    }
}