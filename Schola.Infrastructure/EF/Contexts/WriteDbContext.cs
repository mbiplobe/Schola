using Microsoft.EntityFrameworkCore;
using Schola.Infrastructure.EF.Config;

namespace Schola.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<UserEntity> Users { get; set; } = default!;
    // public DbSet<ClassEntity> Classes { get; set; } = default!;
    // public DbSet<SectionEntity> Sections { get; set; } = default!;

    public WriteDbContext(DbContextOptions<WriteDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(WriteDbContext).Assembly);
    }
}