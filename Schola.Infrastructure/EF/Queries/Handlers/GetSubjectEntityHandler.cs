using Microsoft.EntityFrameworkCore;
using Schola.Infrastructure.EF.Contexts;
using Schola.Shared.Abstractions.Queries;

namespace Schola.Infrastructure.EF.Queries.Handlers;

internal sealed class GetSubjectEntityHandler
    : IQueryHandler<GetAllSubjects, IEnumerable<SubjectEntityDto>>
{
    private readonly ReadDbContext _context;

    public GetSubjectEntityHandler(ReadDbContext context)
        => _context = context;

    public async Task<IEnumerable<SubjectEntityDto>> HandleAsync(GetAllSubjects query)
    {
        var result = await _context.Subjects
            .AsNoTracking()
            .Select(x => x.AsDto())
            .ToListAsync();

        return result;
    }
}