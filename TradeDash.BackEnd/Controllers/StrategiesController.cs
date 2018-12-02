using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeDash.BackEnd.Data;
using TradeDash.BackEnd.Infrastructure;
using Strategy = TradeDash.BackEnd.Data.Strategy;

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
        public async Task<IActionResult> Get()
        {
            var strategies = await _db.Strategies.AsNoTracking()
                .ToListAsync();

            var result = strategies.Select(s => s.MapStrategyResponse());

            return Ok(result);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute] int id)
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
        public async Task<IActionResult> Post([FromBody]TradeDash.DTO.Strategy input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var strategy = new Strategy
            {
                Name = input.Name,
                StrategyType = input.StrategyType,
            };                                                                        

            _db.Strategies.Add(strategy);
            await _db.SaveChangesAsync();

            var result = strategy.MapStrategyResponse();

            return CreatedAtAction(nameof(Get), new {id = result.Id}, result);
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Put([FromRoute]int id, [FromBody]TradeDash.DTO.Strategy input)
        {
            var strategy = await _db.Strategies.FindAsync(id);

            if (strategy == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            strategy.Name = input.Name;
            strategy.StrategyType = input.StrategyType;

            await _db.SaveChangesAsync();

            var result = strategy;

            return Ok(result);
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
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