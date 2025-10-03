using Jordan2.Server.Models;

namespace Jordan2.Client.ViewModels;

public class HomeViewModel
{
    public required IReadOnlyList<Product> Clothing { get; init; }
    public required IReadOnlyList<Product> Accessories { get; init; }
}
