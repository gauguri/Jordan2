namespace Jordan2.Server.Models;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();
    Product? GetById(int id);
    bool Exists(int id);
}
