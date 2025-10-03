namespace Jordan2.Models;

public interface IProductRepository
{
    IReadOnlyList<Product> GetAll();
    Product? GetById(int id);
    bool Exists(int id);
}
