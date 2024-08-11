using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BethanysPieShop.Pages;

public class CheckoutPageModel(IOrderRepository orderRepository, IShoppingCart shoppingCart) : PageModel
{
    [BindProperty]
    public Order Order { get; set; }
    
    public void OnGet()
    {
        
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        List<ShoppingCartItem> items = shoppingCart.GetShoppingCartItems();
        shoppingCart.ShoppingCartItems = items;

        if (shoppingCart.ShoppingCartItems.Count == 0)
        {
            ModelState.AddModelError("", "Your cart is empty, add some pies first");
            return Page();
        }
        
        orderRepository.CreateOrder(Order);
        shoppingCart.ClearCart();
        
        return RedirectToPage("CheckoutCompletePage");
    }
}