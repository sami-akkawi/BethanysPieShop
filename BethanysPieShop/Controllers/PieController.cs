using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository) : Controller
{
    public IActionResult List(string category)
    {
        PieListViewModel pieListViewModel = new(
            string.IsNullOrEmpty(category) 
                ? pieRepository.AllPies.OrderBy(p => p.PieId).ToList() 
                : pieRepository.AllPies.Where(p => p.Category.CategoryName == category).OrderBy(p => p.PieId), 
            string.IsNullOrEmpty(category) 
                ? "All Pies" 
                : categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName
        );
        return View(pieListViewModel);
    }

    public IActionResult Details(int id)
    {
        Pie? pie = pieRepository.GetPieById(id);
        if (pie == null) return NotFound();
        return View(pie);
    }
}