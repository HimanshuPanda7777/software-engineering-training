class Program
{
    class StockException : Exception
{
    public StockException(string msg) : base(msg) { }
}

class CouponException : Exception
{
    public CouponException(string msg) : base(msg) { }
}

    static void Main()
    {
        try
        {
            Customer customer = new Customer(1, "Panda Boss");

            Product mobile = new Product(101, "Mobile", 15000, 5);
            Product charger = new Product(102, "Charger", 500, 10);

            Order order = new Order(1001);

            // Add to cart
            AddToCart(order, mobile, 1);
            AddToCart(order, charger, 2);

            // Place order
            PlaceOrder(order, "SAVE10");

            Console.WriteLine("Order Placed Successfully!");
            Console.WriteLine("Invoice No: INV-" + order.OrderId);
            Console.WriteLine("Total Amount: " + order.TotalAmount);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    static void AddToCart(Order order, Product product, int qty)
    {
        if (qty > product.Stock)
            throw new StockException("Not enough stock for " + product.Name);

        order.Items.Add(new OrderItem(product, qty));
    }

    static void PlaceOrder(Order order, string coupon)
    {
        // Deduct stock
        foreach (var item in order.Items)
        {
            if (item.Quantity > item.Product.Stock)
                throw new StockException("Stock issue while placing order");

            item.Product.Stock -= item.Quantity;
        }

        // Calculate total
        order.CalculateTotal();

        // Apply coupon
        if (coupon == "SAVE10")
            order.TotalAmount *= 0.9;
        else
            throw new CouponException("Invalid coupon");
    }
}
