using Microsoft.EntityFrameworkCore;
using SkyfriCase.Models;

namespace SkyfriCase.Context
{
    public class SkyfriDbContext : DbContext
    {
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }

        public SkyfriDbContext()
        {
        }
        public SkyfriDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
 