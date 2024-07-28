using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository) : Controller
{
    public IActionResult List()
    {
        ViewBag.CurrentCategory = "Cheese cakes";
        return View(pieRepository.AllPies);
    }
}