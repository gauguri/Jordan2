using System.Linq;
using Jordan2.Server.Models;
using Jordan2.Client.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Jordan2.UI.Controllers;

public class HomeController : Controller
{
    private readonly IProductRepository _productRepository;
    private readonly ICartService _cartService;

    public HomeController(IProductRepository productRepository, ICartService cartService)
    {
        _productRepository = productRepository;
        _cartService = cartService;
    }

    public IActionResult Index()
    {
        var allProducts = _productRepository.GetAll();
        var viewModel = new HomeViewModel
        {
            Clothing = allProducts.Where(p => !p.IsAccessory).ToList(),
            Accessories = allProducts.Where(p => p.IsAccessory).ToList()
        };

        ViewBag.CartCount = _cartService.GetCount();
        return View(viewModel);
    }
}
