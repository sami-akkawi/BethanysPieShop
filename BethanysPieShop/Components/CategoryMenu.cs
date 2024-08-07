using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components;

public class CategoryMenu(ICategoryRepository categoryRepository) : ViewComponent
{
    public IViewComponentResult Invoke()
    {
        return View(categoryRepository.AllCategories.OrderBy(c => c.CategoryName));
    }
}