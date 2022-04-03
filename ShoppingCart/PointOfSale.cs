namespace ShoppingCart
{
    public class PointOfSale : ITerminal
    {
        private readonly Dictionary<char, int> productCountMapping;
        public PointOfSale()
        {
            productCountMapping = new Dictionary<char, int>();
        }

        /// <summary>
        /// This method scans the shopping cart and prepares key/value pair of products with their count
        /// </summary>
        /// <param name="item">Shopping cart item</param>
        public void Scan(string item)
        {
            if (string.IsNullOrEmpty(item))
            {
                return;
            }

            // scan all the products in the shopping cart
            foreach (var productCode in item)
            {
                // if this item is scanned for 
                if (!productCountMapping.ContainsKey(productCode))
                {
                    productCountMapping.Add(productCode, 1);
                }
                else
                {
                    productCountMapping[productCode] = ++productCountMapping[productCode];
                }
            }
        }

        /// <summary>
        /// This method calculates total price in the shopping cart
        /// </summary>
        /// <returns>Total price of products in shopping cart</returns>
        public decimal Total()
        {
            var shoppingCartTotalCost = 0M;
            if (productCountMapping.Count == 0)
            {
                return shoppingCartTotalCost;
            }

            foreach (var product in productCountMapping)
            {
                // fetch details about the product 
                var productDetail = ProductMaker.GetProductDetail(product.Key);

                var totalItemsPurchased = product.Value;

                // total purchased unit qualifies for volume discount 
                if (productDetail.MinUnitRequiredForVolumeDiscount > 0 && totalItemsPurchased >= productDetail.MinUnitRequiredForVolumeDiscount)
                {
                    shoppingCartTotalCost += TotalCostWithVolumeDiscount(totalItemsPurchased, productDetail.UnitPrice, productDetail.MinUnitRequiredForVolumeDiscount, productDetail.VolumeDiscountPrice);
                }
                else
                {
                    shoppingCartTotalCost += TotalCostWithoutDiscount(totalItemsPurchased, productDetail.UnitPrice);
                }
            }
            return shoppingCartTotalCost;
        }

        /// <summary>
        /// Helper method to calculate total cost of a product without applying any discount
        /// </summary>
        /// <param name="totalItemsPurchased">Total items bought</param>
        /// <param name="unitPrice">Unit price of a product</param>
        /// <returns>Total cost of a product without discount</returns>
        private static decimal TotalCostWithoutDiscount(int totalItemsPurchased, decimal unitPrice)
        {
            return totalItemsPurchased * unitPrice;
        }

        /// <summary>
        /// Helper method to calculate total cost of a product by applying volume discount
        /// </summary>
        /// <param name="totalItemsPurchased">Total items bought</param>
        /// <param name="unitPrice">unit price</param>
        /// <param name="minUnitForVolumeDiscount">min unit reqd. to get volume discount</param>
        /// <param name="volumeDiscountPrice">volume discount price</param>
        /// <returns>Total cost of a product without discount</returns>
        private static decimal TotalCostWithVolumeDiscount(int totalItemsPurchased, decimal unitPrice, int minUnitForVolumeDiscount, decimal volumeDiscountPrice)
        {
            // calculate how many volumes of items are there to apply discount
            var totalVolumeBought = totalItemsPurchased / minUnitForVolumeDiscount;

            // calculate how many items are remaining after applying volume discount E.g. Among 7 items 6 qualified for volume discount 1 remaining
            var remainingItemFromVolume = totalItemsPurchased % minUnitForVolumeDiscount;

            // total cost of all products
            return totalVolumeBought * volumeDiscountPrice + TotalCostWithoutDiscount(remainingItemFromVolume, unitPrice);
        }
    }
}
