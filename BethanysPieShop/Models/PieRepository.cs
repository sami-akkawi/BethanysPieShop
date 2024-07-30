using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Models;

public class PieRepository(BenathysPieShopDbContext benathysPieShopDbContext) : IPieRepository
{
    public IEnumerable<Pie> AllPies
    {
        get
        {
            return benathysPieShopDbContext.Pies.Include(c => c.Category);
        }
    }

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get
        {
            return AllPies.Where(p => p.IsPieOfTheWeek);
        }
    }

    public Pie? GetPieById(int pieId)
    {
        throw new NotImplementedException();
    }
}