namespace Jordan2.Server.Models;

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Brand { get; set; }
    public required string Description { get; set; }
    public decimal Price { get; set; }
    public required string Preview { get; set; }
    public required IReadOnlyList<string> Photos { get; set; }
    public bool IsAccessory { get; set; }
}
