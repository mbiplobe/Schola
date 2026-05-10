using Schola.Application.DTOs;
using Schola.Application.Queries;
using Schola.Domain.Entities;
using Schola.Infrastructure.EF.Contexts;
using Schola.Infrastructure.EF.Models;
using Schola.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;

namespace Schola.Infrastructure.EF.Queries.Handlers;

internal sealed class GetSampleEntityHandler : IQueryHandler<GetSampleEntity, SampleEntityDto>
{
    private readonly DbSet<SampleEntityReadModel> _SampleEntities;

    public GetSampleEntityHandler(ReadDbContext context)
        => _SampleEntities = context.SampleEntities;

    public Task<SampleEntityDto> HandleAsync(GetSampleEntity query)
        => _SampleEntities
            .Include(pl => pl.Items)
            .Where(pl => pl.Id == query.Id)
            .Select(pl => pl.AsDto())
            .AsNoTracking()
            .SingleOrDefaultAsync();
}
