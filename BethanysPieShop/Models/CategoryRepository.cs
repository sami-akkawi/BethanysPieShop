namespace BethanysPieShop.Models;

public class CategoryRepository(BenathysPieShopDbContext benathysPieShopDbContext) : ICategoryRepository
{
    public IEnumerable<Category> AllCategories
    {
        get
        {
            return benathysPieShopDbContext.Categories.OrderBy(c => c.CategoryName);
        }
    }
}