namespace BethanysPieShop.Models;

public class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }
    public Pie Pie { get; set; } = default!;
    public int Amount { get; set; }
    public Guid? ShoppingCartId { get; set; }
}