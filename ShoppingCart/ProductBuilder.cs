namespace ShoppingCart
{
    public partial class Product
    {
        public class ProductBuilder
        {
            private readonly Product product = new();

            /// <summary>
            /// Adds Code to product being built
            /// </summary>
            /// <param name="productCode">Product Code</param>
            /// <returns>Product object Code</returns>
            public ProductBuilder Code(char productCode)
            {
                product.Code = productCode;
                return this;
            }

            /// <summary>
            /// Adds UnitPrice to product being built
            /// </summary>
            /// <param name="unitPrice">Unit price of the product</param>
            /// <returns>Product object with UnitPrice</returns>
            public ProductBuilder UnitPrice(decimal unitPrice)
            {
                product.UnitPrice = unitPrice;
                return this;
            }

            /// <summary>
            /// Adds MinUnitForVolumeDiscount to product being built
            /// </summary>
            /// <param name="minUnitRequiredForVolumeDiscount">min. quantity required to get volume discount</param>
            /// <returns>Product object with MinUnitForVolumeDiscount</returns>
            public ProductBuilder MinUnitRequiredForVolumeDiscount(int minUnitRequiredForVolumeDiscount)
            {
                product.MinUnitRequiredForVolumeDiscount = minUnitRequiredForVolumeDiscount;
                return this;
            }

            /// <summary>
            /// Adds volumeDiscountPrice to product being built
            /// </summary>
            /// <param name="volumeDiscountPrice">discounted price per volume</param>
            /// <returns>Product object with volumeDiscountPrice</returns>
            public ProductBuilder VolumeDiscountPrice(int volumeDiscountPrice)
            {
                product.VolumeDiscountPrice = volumeDiscountPrice;
                return this;
            }

            /// <summary>
            /// Builds the Product object 
            /// </summary>
            /// <returns>Product object built</returns>
            public Product Build() => product;
        }
    }
}