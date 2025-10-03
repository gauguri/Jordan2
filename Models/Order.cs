namespace Jordan2.Models;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public decimal Total { get; set; }
    public required IReadOnlyList<OrderLine> Lines { get; set; }
}

public class OrderLine
{
    public required Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal LineTotal { get; set; }
}
