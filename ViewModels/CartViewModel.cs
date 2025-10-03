using Jordan2.Models;

namespace Jordan2.ViewModels;

public class CartViewModel
{
    public required IReadOnlyList<CartItemDetail> Items { get; init; }
    public decimal Total { get; init; }
}

public class CartItemDetail
{
    public required Product Product { get; init; }
    public int Quantity { get; init; }
    public decimal LineTotal { get; init; }
}
