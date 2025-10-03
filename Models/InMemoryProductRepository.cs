using System.Collections.ObjectModel;
using System.Linq;

namespace Jordan2.Models;

public class InMemoryProductRepository : IProductRepository
{
    private readonly ReadOnlyCollection<Product> _products;

    public InMemoryProductRepository()
    {
        var products = new List<Product>
        {
            new()
            {
                Id = 1,
                Name = "Air Jordan 1 Mid SE",
                Brand = "Nike",
                Description = "The iconic Air Jordan 1 Mid SE combines premium leather with responsive cushioning for everyday wear.",
                Price = 11999m,
                Preview = "https://images.unsplash.com/photo-1611214046753-6fb3cd43dc0e?auto=format&fit=crop&w=600&q=80",
                Photos = new[]
                {
                    "https://images.unsplash.com/photo-1611214046753-6fb3cd43dc0e?auto=format&fit=crop&w=600&q=80",
                    "https://images.unsplash.com/photo-1511557872300-48a34643c9c8?auto=format&fit=crop&w=600&q=80",
                    "https://images.unsplash.com/photo-1542291026-7eec264c27ff?auto=format&fit=crop&w=600&q=80"
                },
                IsAccessory = false
            },
            new()
            {
                Id = 2,
                Name = "Jordan Essentials Fleece Hoodie",
                Brand = "Nike",
                Description = "A soft fleece hoodie with Jumpman branding that keeps you warm before and after the game.",
                Price = 5499m,
                Preview = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?auto=format&fit=crop&w=600&q=80",
                Photos = new[]
                {
                    "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?auto=format&fit=crop&w=600&q=80",
                    "https://images.unsplash.com/photo-1523381210434-271e8be1f52b?auto=format&fit=crop&w=600&q=80"
                },
                IsAccessory = false
            },
            new()
            {
                Id = 3,
                Name = "Jordan Flight MVP T-Shirt",
                Brand = "Nike",
                Description = "A breathable cotton tee featuring bold Flight graphics inspired by classic Jordan posters.",
                Price = 2499m,
                Preview = "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?auto=format&fit=crop&w=600&q=80",
                Photos = new[]
                {
                    "https://images.unsplash.com/photo-1521572163474-6864f9cf17ab?auto=format&fit=crop&w=600&q=80",
                    "https://images.unsplash.com/photo-1524504388940-b1c1722653e1?auto=format&fit=crop&w=600&q=80"
                },
                IsAccessory = false
            },
            new()
            {
                Id = 4,
                Name = "Jordan Jumpman Cap",
                Brand = "Nike",
                Description = "A structured six-panel cap with adjustable closure and embroidered Jumpman logo.",
                Price = 1999m,
                Preview = "https://images.unsplash.com/photo-1516478177764-9fe5bd16f377?auto=format&fit=crop&w=600&q=80",
                Photos = new[]
                {
                    "https://images.unsplash.com/photo-1516478177764-9fe5bd16f377?auto=format&fit=crop&w=600&q=80",
                    "https://images.unsplash.com/photo-1532296071-1b4c349a4d87?auto=format&fit=crop&w=600&q=80"
                },
                IsAccessory = true
            },
            new()
            {
                Id = 5,
                Name = "Jordan Everyday Crew Socks (3-Pack)",
                Brand = "Nike",
                Description = "Soft and supportive crew socks with moisture-wicking fabric to keep you comfortable on and off the court.",
                Price = 1299m,
                Preview = "https://images.unsplash.com/photo-1523381210434-271e8be1f52b?auto=format&fit=crop&w=600&q=80",
                Photos = new[]
                {
                    "https://images.unsplash.com/photo-1523381210434-271e8be1f52b?auto=format&fit=crop&w=600&q=80",
                    "https://images.unsplash.com/photo-1503342217505-b0a15ec3261c?auto=format&fit=crop&w=600&q=80"
                },
                IsAccessory = true
            },
            new()
            {
                Id = 6,
                Name = "Jordan Sport Dri-FIT Headband",
                Brand = "Nike",
                Description = "Stretchy Dri-FIT headband that helps manage sweat while you move.",
                Price = 899m,
                Preview = "https://images.unsplash.com/photo-1489987707025-afc232f7ea0f?auto=format&fit=crop&w=600&q=80",
                Photos = new[]
                {
                    "https://images.unsplash.com/photo-1489987707025-afc232f7ea0f?auto=format&fit=crop&w=600&q=80",
                    "https://images.unsplash.com/photo-1487412912498-0447578fcca8?auto=format&fit=crop&w=600&q=80"
                },
                IsAccessory = true
            }
        };

        _products = new ReadOnlyCollection<Product>(products);
    }

    public IReadOnlyList<Product> GetAll() => _products;

    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);

    public bool Exists(int id) => _products.Any(p => p.Id == id);
}
