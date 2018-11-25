using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeDash.BackEnd.Data;
using TradeDash.BackEnd.Infrastructure;
using TradeDash.DTO;
using Strategy = TradeDash.BackEnd.Data.Strategy;
using StrategyType = TradeDash.DTO.StrategyType;

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
                .ToListAsync();

            var result = strategies.Select(s => s.MapStrategyResponse());

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStrategy([FromRoute] int id)
        {
            var strategy = await _db.FindAsync<Strategy>(id);
            
            if (strategy == null)
            {
                return NotFound();
            }

            var result = strategy.MapStrategyResponse();
    
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateStrategy([FromBody]TradeDash.DTO.Strategy input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var strategy = new Strategy
            {
                Name = input.Name,
                StrategyType = StrategyType.Default,
            };                                                                        

            _db.Strategies.Add(strategy);
            await _db.SaveChangesAsync();

            var result = strategy.MapStrategyResponse();

            return CreatedAtAction(nameof(GetStrategy), new {id = result.Id}, result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteStrategy([FromRoute]int id)
        {
            var strategy = await _db.FindAsync<Strategy>(id);

            if (strategy == null)
            {
                return NotFound();
            }

            _db.Remove(strategy);
            
            //TODO: Handle exceptions
            await _db.SaveChangesAsync();

            return NoContent();
        }
    }
}