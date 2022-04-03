namespace ShoppingCart.Exceptions
{
    /// <summary>
    /// Use this exception when product does not exist in the system
    /// </summary>
    public class ProductNotExistException : Exception
    {
        public ProductNotExistException(string message) : base(message)
        {

        }
    }
}