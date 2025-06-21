using ControlFina.Core.Features.Categories.Entities;
using ControlFina.Core.Features.Transactions.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlFina.Infrastructure.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        // Enable legacy timestamp behavior for PostgreSQL compatibility
        // This is necessary to handle DateTime values correctly in PostgreSQL
        // when using Npgsql, especially for older versions or specific configurations.
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<Transaction> Transactions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        modelBuilder.HasDefaultSchema(Schemas.Default);
    }
}
