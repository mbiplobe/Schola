using Schola.Infrastructure.EF.Config;
using Schola.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Schola.Infrastructure.EF.Contexts;

internal sealed class ReadDbContext : DbContext
{
    public DbSet<SampleEntityReadModel> SampleEntities { get; set; }



    public ReadDbContext(DbContextOptions<ReadDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("SampleEntity");

        var configuration = new ReadConfiguration();
        modelBuilder.ApplyConfiguration<SampleEntityReadModel>(configuration);
        modelBuilder.ApplyConfiguration<SampleEntityItemReadModel>(configuration);
    }
}
