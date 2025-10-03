using Jordan2.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace Jordan2.UI.Controllers;

public class ProductsController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICartService _cartService;

    public ProductsController(IProductRepository productRepository, ICartService cartService)
    {
        _productRepository = productRepository;
        _cartService = cartService;
    }

    public IActionResult Details(int id)
    {
        var product = _productRepository.GetById(id);
        if (product is null)
        {
            return NotFound();
        }

        ViewBag.CartCount = _cartService.GetCount();
        return View(product);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddToCart(int id)
    {
        if (!_productRepository.Exists(id))
        {
            return NotFound();
        }

        _cartService.AddProduct(id);
        return RedirectToAction("Details", new { id });
    }
}
