using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeDash.BackEnd.Models;

namespace TradeDash.BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StrategiesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public StrategiesController(ApplicationDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetStrategies()
        {
            var strategies = await _db.Strategies.AsNoTracking()
                .Include(m => m.MoneyManagement)
                .ToListAsync();

            return Ok(strategies);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStrategy([FromRoute] int id)
        {
            var strategy = await _db.Strategies.AsNoTracking()
                .Include(m => m.MoneyManagement)
                .SingleOrDefaultAsync(s => s.Id == id);

            if (strategy == null)
            {
                return NotFound();
            }

            return Ok(strategy);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStrategy([FromBody]Strategy input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = new Strategy
            {
                Name = input.Name,
            };

            _db.Strategies.Add(strategy);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetStrategy), new {id = strategy.Id}, strategy);
        }
    }
}