using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using SkyfriCase.Context;

namespace SkyfriCase
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<SkyfriDbContext>
    {
        public SkyfriDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<SkyfriDbContext> dbContextOptionsBuilder = new();
            dbContextOptionsBuilder.UseSqlServer(Configuration.ConnectionString);
            return new(dbContextOptionsBuilder.Options);
        }
    }
}
