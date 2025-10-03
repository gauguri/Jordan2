using System.Linq;
using Jordan2.Models;
using Jordan2.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jordan2.Controllers;

public class CartController : Controller
{
    private readonly ICartService _cartService;
    private readonly IProductRepository _productRepository;
    private readonly IOrderRepository _orderRepository;

    public CartController(ICartService cartService, IProductRepository productRepository, IOrderRepository orderRepository)
    {
        _cartService = cartService;
        _productRepository = productRepository;
        _orderRepository = orderRepository;
    }

    public IActionResult Index()
    {
        var viewModel = BuildCartViewModel();
        ViewBag.CartCount = _cartService.GetCount();
        return View(viewModel);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Add(int id)
    {
        if (!_productRepository.Exists(id))
        {
            return NotFound();
        }

        _cartService.AddProduct(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Remove(int id)
    {
        _cartService.RemoveProduct(id);
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Clear()
    {
        _cartService.Clear();
        return RedirectToAction("Index");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Checkout()
    {
        var items = BuildCartItemDetails();
        if (items.Count == 0)
        {
            return RedirectToAction("Index");
        }

        var order = _orderRepository.CreateOrder(items.Select(i => new OrderLine
        {
            Product = i.Product,
            Quantity = i.Quantity,
            LineTotal = i.LineTotal
        }));

        _cartService.Clear();
        return RedirectToAction("Confirmation", new { id = order.Id });
    }

    public IActionResult Confirmation(int id)
    {
        var order = _orderRepository.GetById(id);
        if (order is null)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewBag.CartCount = _cartService.GetCount();
        return View(order);
    }

    private CartViewModel BuildCartViewModel()
    {
        var items = BuildCartItemDetails();
        return new CartViewModel
        {
            Items = items,
            Total = items.Sum(i => i.LineTotal)
        };
    }

    private List<CartItemDetail> BuildCartItemDetails()
    {
        var items = _cartService.GetItems();
        var details = new List<CartItemDetail>();
        foreach (var item in items)
        {
            var product = _productRepository.GetById(item.ProductId);
            if (product is null)
            {
                continue;
            }

            var lineTotal = product.Price * item.Quantity;
            details.Add(new CartItemDetail
            {
                Product = product,
                Quantity = item.Quantity,
                LineTotal = lineTotal
            });
        }

        return details;
    }
}
