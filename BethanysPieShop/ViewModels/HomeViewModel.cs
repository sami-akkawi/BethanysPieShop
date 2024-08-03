using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels;

public class HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
{
    public IEnumerable<Pie> PiesOfTheWeek => piesOfTheWeek;
}