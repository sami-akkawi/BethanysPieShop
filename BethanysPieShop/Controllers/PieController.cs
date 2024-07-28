using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository) : Controller
{
    public IActionResult List()
    {
        PieListViewModel pieListViewModel = new(pieRepository.AllPies, "Cheese cakes");
        return View(pieListViewModel);
    }
}