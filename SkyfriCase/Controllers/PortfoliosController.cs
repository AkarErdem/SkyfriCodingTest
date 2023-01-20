using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyfriCase.Context;
using SkyfriCase.Models;

namespace SkyfriCase.Controllers
{
    [Route("api/portfolios")]
    [ApiController]
    public class PortfoliosController : ControllerBase
    {
        private readonly SkyfriDbContext _context;

        public PortfoliosController(SkyfriDbContext context)
        {
            _context = context;
        }

        // GET: api/portfolios/{tenantId}
        [HttpGet("{tenantId:guid}")]
        public async Task<ActionResult<IEnumerable<Portfolio>>> GetPortfolios(Guid tenantId)
        {
            var portfolios = await _context.Portfolios.Where(p => p.TenantId == tenantId).ToListAsync();
            if (portfolios == null)
            {
                return NotFound($"Given {nameof(tenantId)} does not exist.");
            }

            return Ok(portfolios);
        }

        // POST: api/portfolios
        [HttpPost]
        public async Task<ActionResult<Portfolio>> AddPortfolio([FromBody] PortfolioDTO portfolioDto)
        {
            var tenant = await _context.Tenants.FindAsync(portfolioDto.TenantId);
            if (tenant == null)
            {
                return NotFound($"Given {nameof(portfolioDto.TenantId)} does not exist.");
            }

            var portfolio = new Portfolio
            {
                PortfolioId = Guid.NewGuid(),
                PortfolioName = portfolioDto.PortfolioName,
                TenantId = portfolioDto.TenantId,
                Tenant = tenant
            };
            _context.Portfolios.Add(portfolio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPortfolios), new { tenantId = portfolioDto.TenantId }, portfolio);
        }

        // DELETE: api/portfolios/{portfolioId}
        [HttpDelete("{portfolioId:guid}")]
        public async Task<ActionResult<Portfolio>> DeletePortfolio(Guid portfolioId)
        {
            var portfolio = await _context.Portfolios.FindAsync(portfolioId);
            if (portfolio == null)
            {
                return NotFound($"Given {nameof(portfolioId)} does not exist.");
            }

            _context.Portfolios.Remove(portfolio);
            await _context.SaveChangesAsync();

            return portfolio;
        }
    }
}
