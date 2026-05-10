using Schola.Application.Services;
using Schola.Infrastructure.EF.Contexts;
using Schola.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Schola.Infrastructure.EF.Services;

internal sealed class SampleEntityReadService : ISampleEntityReadService
{
    private readonly DbSet<SampleEntityReadModel> _sampleEntity;

    public SampleEntityReadService(ReadDbContext context)
        => _sampleEntity = context.SampleEntities;

    public Task<bool> ExistsByNameAsync(string name)
        => _sampleEntity.AnyAsync(pl => pl.Name == name);
}
