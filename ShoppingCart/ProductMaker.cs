using ShoppingCart.Exceptions;
using static ShoppingCart.Product;

namespace ShoppingCart
{
    /// <summary>
    /// Utility Method for Product class
    /// </summary>
    public static class ProductMaker
    {
        public static Product GetProductDetail(char productCode)
        {
            switch (productCode)
            {
                case 'A':
                    return new ProductBuilder()
                        .Code('A')
                        .UnitPrice(2)
                        .MinUnitRequiredForVolumeDiscount(4)
                        .VolumeDiscountPrice(7)
                        .Build();

                case 'B':
                    return new ProductBuilder()
                        .Code('B')
                        .UnitPrice(12)
                        .Build();

                case 'C':
                    return new ProductBuilder()
                    .Code('C')
                    .UnitPrice(1.25M)
                    .MinUnitRequiredForVolumeDiscount(6)
                    .VolumeDiscountPrice(6)
                    .Build();

                case 'D':
                    return new ProductBuilder()
                        .Code('D')
                        .UnitPrice(0.15M)
                        .Build();

                default:
                    throw new ProductNotExistException("Product does not exist in the system.");
            }
        }
    }
}
