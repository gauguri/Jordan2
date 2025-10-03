namespace Jordan2.Server.Models;

public interface ICartService
{
    IReadOnlyList<CartItem> GetItems();
    void AddProduct(int productId);
    void RemoveProduct(int productId);
    void Clear();
    int GetCount();
}
