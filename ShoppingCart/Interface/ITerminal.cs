namespace ShoppingCart
{
    public interface ITerminal
    {
        void Scan(string item);
        decimal Total();
    }
}
