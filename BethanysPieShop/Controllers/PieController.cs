using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository) : Controller
{
    public IActionResult List()
    {
        PieListViewModel pieListViewModel = new(pieRepository.AllPies, "All Pies");
        return View(pieListViewModel);
    }

    public IActionResult Details(int id)
    {
        Pie? pie = pieRepository.GetPieById(id);
        if (pie == null) return NotFound();
        return View(pie);
    }
}