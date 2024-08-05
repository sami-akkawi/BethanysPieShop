using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels;

public class ShoppingCartViewModel(IShoppingCart shoppingCart)
{
    public IShoppingCart ShoppingCart => shoppingCart;
    public decimal ShoppingCartTotal => shoppingCart.GetShoppingCartTotal();
}