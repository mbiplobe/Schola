using Schola.Domain.Entities;
using Schola.Domain.ValueObjects;
using Schola.Infrastructure.EF.Config;
using Microsoft.EntityFrameworkCore;

namespace Schola.Infrastructure.EF.Contexts;

internal sealed class WriteDbContext : DbContext
{
    public DbSet<SampleEntity> SampleEntities { get; set; }



    public WriteDbContext(DbContextOptions<WriteDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("SampleEntity");

        var configuration = new WriteConfiguration();
        modelBuilder.ApplyConfiguration<SampleEntity>(configuration);
        modelBuilder.ApplyConfiguration<SampleEntityItem>(configuration);
    }
}
