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
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        throw new NotImplementedException();
    }
}