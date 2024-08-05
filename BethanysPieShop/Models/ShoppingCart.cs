using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class ShoppingCart(BethanysPieShopDbContext bethanysPieShopDbContext) : IShoppingCart
{
    public Guid ShoppingCartId { private set; get; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }
    
    public static ShoppingCart GetCart(IServiceProvider services)
    {
        ISession? session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;
        BethanysPieShopDbContext dbContext = services.GetRequiredService<BethanysPieShopDbContext>() ?? throw new Exception("Error initializing");

        Guid cartId = new Guid(session?.GetString("CartId") ?? Guid.NewGuid().ToString());

        return new ShoppingCart(dbContext) { ShoppingCartId = cartId };
    }
    
    public void AddToCart(Pie pie)
    {
        var shoppingCartItem = bethanysPieShopDbContext.ShoppingCartItems.SingleOrDefault(
            s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId
        );

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                Pie = pie,
                Amount = 1
            };
        }
        else
        {
            shoppingCartItem.Amount++;
        }

        bethanysPieShopDbContext.SaveChanges();
    }

    public int RemoveFromCart(Pie pie)
    {
        var shoppingCartItem = bethanysPieShopDbContext.ShoppingCartItems.SingleOrDefault(
            s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId
        );

        if (shoppingCartItem == null)
        {
            return 0;
        }

        int localAmount = 0;
        if (shoppingCartItem.Amount > 1)
        {
            shoppingCartItem.Amount--;
            localAmount = shoppingCartItem.Amount;
        }
        else
        {
            bethanysPieShopDbContext.ShoppingCartItems.Remove(shoppingCartItem);
        }
        bethanysPieShopDbContext.SaveChanges();

        return localAmount;
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ??= bethanysPieShopDbContext.ShoppingCartItems
            .Where(i => i.ShoppingCartId == ShoppingCartId)
            .Include(i => i.Pie)
            .ToList();
    }

    public void ClearCart()
    {
        var items = bethanysPieShopDbContext.ShoppingCartItems
            .Where(i => i.ShoppingCartId == ShoppingCartId);
        
        bethanysPieShopDbContext.ShoppingCartItems.RemoveRange(items);
        bethanysPieShopDbContext.SaveChanges();
    }

    public decimal GetShoppingCartTotal()
    {
        return bethanysPieShopDbContext.ShoppingCartItems
            .Where(i => i.ShoppingCartId == ShoppingCartId)
            .Select(i => i.Pie.Price * i.Amount)
            .Sum();
    }
}