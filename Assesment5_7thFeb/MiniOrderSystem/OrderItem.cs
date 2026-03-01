class OrderItem
{
    public Product Product;
    public int Quantity;

    public OrderItem(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public double GetTotal()
    {
        return Product.Price * Quantity;
    }
}
