using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class SearchController(IPieRepository pieRepository) : ControllerBase
{
    [HttpGet]
    public IActionResult GetAll()
    {
        IEnumerable<Pie> pies = pieRepository.AllPies;
        
        return Ok(pies);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        Pie? pie = pieRepository.GetPieById(id);
        if (pie == null) return NotFound();
        
        return Ok(pie);
    }

    [HttpPost]
    public IActionResult SearchPies([FromBody]string searchQuery)
    {
        IEnumerable<Pie> pies = new List<Pie>();
        
        if (!string.IsNullOrEmpty(searchQuery))
        {
            pies = pieRepository.SearchPies(searchQuery);
        }
        
        return new JsonResult(pies);
    }
}