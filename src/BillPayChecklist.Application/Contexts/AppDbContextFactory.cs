using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace BillPayChecklist.Application.Contexts
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
            => new AppDbContext(new DbContextOptionsBuilder<AppDbContext>().UseSqlite().Options);
    }
}