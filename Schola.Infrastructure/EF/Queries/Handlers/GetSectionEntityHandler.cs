using Microsoft.EntityFrameworkCore;
using Schola.Infrastructure.EF.Contexts;
using Schola.Infrastructure.EF.Queries;
using Schola.Shared.Abstractions.Queries;

internal sealed class GetSectionEntityHandler : IQueryHandler<GetSections, IEnumerable<SectionEntityDto>>
{
    private readonly ReadDbContext _context;

    public GetSectionEntityHandler(ReadDbContext context)
        => _context = context;

    public async Task<IEnumerable<SectionEntityDto>> HandleAsync(GetSections query)
    {
        var result = await _context.Sections
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();

        return result;
    }
}
   