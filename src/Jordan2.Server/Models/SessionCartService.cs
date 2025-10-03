using System.Linq;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace Jordan2.Server.Models;

public class SessionCartService : ICartService
{
    private const string CartSessionKey = "CartItems";
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SessionCartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public IReadOnlyList<CartItem> GetItems()
    {
        var session = GetSession();
        var data = session.GetString(CartSessionKey);
        if (string.IsNullOrEmpty(data))
        {
            return Array.Empty<CartItem>();
        }

        var items = JsonSerializer.Deserialize<List<CartItem>>(data);
        return items is null || items.Count == 0 ? Array.Empty<CartItem>() : items;
    }

    public void AddProduct(int productId)
    {
        var items = GetItems().ToList();
        var existing = items.FirstOrDefault(i => i.ProductId == productId);
        if (existing is null)
        {
            items.Add(new CartItem { ProductId = productId, Quantity = 1 });
        }
        else
        {
            existing.Quantity += 1;
        }

        SaveItems(items);
    }

    public void RemoveProduct(int productId)
    {
        var items = GetItems().ToList();
        var existing = items.FirstOrDefault(i => i.ProductId == productId);
        if (existing is null)
        {
            return;
        }

        existing.Quantity -= 1;
        if (existing.Quantity <= 0)
        {
            items.Remove(existing);
        }

        SaveItems(items);
    }

    public void Clear()
    {
        GetSession().Remove(CartSessionKey);
    }

    public int GetCount() => GetItems().Sum(i => i.Quantity);

    private void SaveItems(IEnumerable<CartItem> items)
    {
        var session = GetSession();
        session.SetString(CartSessionKey, JsonSerializer.Serialize(items));
    }

    private ISession GetSession()
    {
        var context = _httpContextAccessor.HttpContext ??
                      throw new InvalidOperationException("No active HTTP context is available.");
        return context.Session;
    }
}
