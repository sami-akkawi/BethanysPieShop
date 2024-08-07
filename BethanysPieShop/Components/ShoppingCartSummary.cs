using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components;

public class ShoppingCartSummary(IShoppingCart shoppingCart) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        List<ShoppingCartItem> items = shoppingCart.GetShoppingCartItems();
        shoppingCart.ShoppingCartItems = items;

        ShoppingCartViewModel shoppingCartViewModel = new(shoppingCart);

        return View(shoppingCartViewModel);
    }
}