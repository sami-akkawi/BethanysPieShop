using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class HomeController(IPieRepository pieRepository) : Controller
{
    public IActionResult Index()
    {
        IEnumerable<Pie> piesOfTheWeek = pieRepository.PiesOfTheWeek;
        HomeViewModel homeViewModel = new(piesOfTheWeek);
        return View(homeViewModel);
    }
}