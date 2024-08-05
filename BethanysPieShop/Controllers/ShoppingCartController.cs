using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart) : Controller
{
    public ViewResult Index()
    {
        List<ShoppingCartItem> items = shoppingCart.GetShoppingCartItems();
        shoppingCart.ShoppingCartItems = items;

        ShoppingCartViewModel shoppingCartViewModel = new(shoppingCart);

        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int pieId)
    {
        Pie? selectedPie = pieRepository.GetPieById(pieId);
        if (selectedPie != null)
        {
            shoppingCart.AddToCart(selectedPie);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int pieId)
    {
        Pie? selectedPie = pieRepository.GetPieById(pieId);
        if (selectedPie != null)
        {
            shoppingCart.RemoveFromCart(selectedPie);
        }

        return RedirectToAction("Index");
    }
}