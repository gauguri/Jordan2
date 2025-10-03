using Jordan2.Models;

namespace Jordan2.ViewModels;

public class HomeViewModel
{
    public required IReadOnlyList<Product> Clothing { get; init; }
    public required IReadOnlyList<Product> Accessories { get; init; }
}
