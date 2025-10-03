namespace Jordan2.Models;

public interface ICartService
{
    IReadOnlyList<CartItem> GetItems();
    void AddProduct(int productId);
    void RemoveProduct(int productId);
    void Clear();
    int GetCount();
}
