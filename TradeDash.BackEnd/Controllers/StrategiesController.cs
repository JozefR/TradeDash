using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TradeDash.BackEnd.Data;
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
                .Include(m => m.MoneyManagement)
                .Include(r => r.ReturnOnStrategy)
                .ToListAsync();

            return Ok(strategies.Select(s => new StrategyResponse
            {
                Id = s.Id,
                Name = s.Name,
                StrategyType = s.StrategyType
            }));
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetStrategy([FromRoute] int id)
        {
            var strategy = await _db.FindAsync<Strategy>(id);
            
            if (strategy == null)
            {
                return NotFound();
            }

            var result = new StrategyResponse
            {
                Id = strategy.Id,
                Name = strategy.Name,
                StrategyType = strategy.StrategyType
            };

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

            var result = new StrategyResponse
            {
                Id = strategy.Id,
                Name = strategy.Name
            };

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