using BlazingPizza;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBlazorHybridApp.Shared.Models;
using MyBlazorHybridApp.Web.Data;

namespace MyBlazorHybridApp.Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SpecialsController : ControllerBase
{
    private readonly PizzaStoreContext _db;

    public SpecialsController(PizzaStoreContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<List<PizzaSpecial>>> GetSpecials()
    {
        return await _db.Specials
                    .OrderByDescending(s => (double)s.BasePrice)
                    .ToListAsync();
    }
}
