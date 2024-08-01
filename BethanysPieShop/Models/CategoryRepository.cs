namespace BethanysPieShop.Models;

public class CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext) : ICategoryRepository
{
    public IEnumerable<Category> AllCategories
    {
        get
        {
            return bethanysPieShopDbContext.Categories.OrderBy(c => c.CategoryName);
        }
    }
}