using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace BethanysPieShop.Models;

public class PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext) : IPieRepository
{
    public IEnumerable<Pie> AllPies
    {
        get
        {
            return bethanysPieShopDbContext
                .Pies
                .Include(c => c.Category);
        }
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get
        {
            return bethanysPieShopDbContext
                .Pies
                .Where(p => p.IsPieOfTheWeek)
                .Include(c => c.Category);
        }
    }

    public Pie? GetPieById(int pieId)
    {
        IQueryable<Pie> pie = bethanysPieShopDbContext.Pies.Where(p => p.PieId == pieId);
        if (pie.IsNullOrEmpty()) return null;
        return pie.First();
    }
}