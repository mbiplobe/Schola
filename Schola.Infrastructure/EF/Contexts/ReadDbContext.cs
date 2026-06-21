using Microsoft.EntityFrameworkCore;
using Schola.Infrastructure.EF.Models;

namespace Schola.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<UserReadModel> Users { get; set; } = default!;
    // public DbSet<StudentReadModel> Students { get; set; } = default!;
    // public DbSet<GuardianReadModel> Guardians { get; set; } = default!;
    // public DbSet<StudentGuardianMapReadModel> StudentGuardianMaps { get; set; } = default!;
    // public DbSet<GuardianRelationshipReadModel> GuardianRelationships { get; set; } = default!;
    // public DbSet<ClassReadModel> Classes { get; set; } = default!;

    public ReadDbContext(DbContextOptions<ReadDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.ApplyConfigurationsFromAssembly(
            typeof(ReadDbContext).Assembly);
    }
}