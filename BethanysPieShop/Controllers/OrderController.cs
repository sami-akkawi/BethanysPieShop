using BethanysPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

[Authorize]
public class OrderController(IOrderRepository orderRepository, IShoppingCart shoppingCart) : Controller
{
    public IActionResult Checkout()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Checkout(Order order)
    {
        List<ShoppingCartItem> items = shoppingCart.GetShoppingCartItems();
        shoppingCart.ShoppingCartItems = items;

        if (shoppingCart.ShoppingCartItems.Count == 0)
        {
            ModelState.AddModelError("", "Your cart is empty, add some pies first");
        }

        if (ModelState.IsValid)
        {
            orderRepository.CreateOrder(order);
            shoppingCart.ClearCart();
            return RedirectToAction("CheckoutComplete");
        }
        
        return View(order);
    }
    
    public IActionResult CheckoutComplete()
    {
        ViewBag.CheckoutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
        return View();
    }
}