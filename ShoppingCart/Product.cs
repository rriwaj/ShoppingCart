namespace ShoppingCart
{
    // Data structure to contain product 
    public partial class Product
    {
        private Product()
        {
            // making constructor private to avoid unmanaged object creation
        }

        /// <summary>
        /// product code
        /// </summary>
        public char Code { get; private set; }

        /// <summary>
        /// what does one unit of product cost 
        /// </summary>
        public decimal UnitPrice { get; private set; }

        /// <summary>
        /// minimum quantity required to get volume discount
        /// </summary>
        public int MinUnitRequiredForVolumeDiscount { get; private set; }

        /// <summary>
        /// volume discount price 
        /// </summary>
        public decimal VolumeDiscountPrice { get; private set; }
    }
}