using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SkyfriCase.Context;
using SkyfriCase.Models;

namespace SkyfriCase.Controllers
{
    [Route("api/tenants")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        private readonly SkyfriDbContext _context;

        public TenantsController(SkyfriDbContext context)
        {
            _context = context;
        }

        // GET: api/tenants
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tenant>>> GetTenants()
        {
            return await _context.Tenants.ToListAsync();
        }

        // POST: api/tenants
        [HttpPost]
        public async Task<ActionResult<Tenant>> AddTenant([FromBody] TenantDTO tenantDto)
        {
            var tenant = new Tenant
            {
                TenantName = tenantDto.TenantName,
                TenantId = Guid.NewGuid()
            };
            _context.Tenants.Add(tenant);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTenants), new { id = tenant.TenantId }, tenant);
        }

        // DELETE: api/tenants
        [HttpDelete("{tenantId:guid}")]
        public async Task<ActionResult<Tenant>> DeleteTenant(Guid tenantId)
        {
            var tenant = await _context.Tenants.FindAsync(tenantId);
            if (tenant == null)
            {
                return NotFound($"Given {nameof(tenantId)} does not exist.");
            }

            _context.Tenants.Remove(tenant);
            await _context.SaveChangesAsync();

            return tenant;
        }
    }
}
