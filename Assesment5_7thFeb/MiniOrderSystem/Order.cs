class Order
{
    public int OrderId;
    public List<OrderItem> Items = new List<OrderItem>();
    public double TotalAmount;

    public Order(int id)
    {
        OrderId = id;
    }

    public void CalculateTotal()
    {
        TotalAmount = 0;
        foreach (var item in Items)
            TotalAmount += item.GetTotal();
    }
}
