using ControlFina.Core.Features.Categories.Entities;
using ControlFina.Core.Features.Transactions.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlFina.Infrastructure.Database;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.HasDefaultSchema(Schemas.Default);
    }
}
