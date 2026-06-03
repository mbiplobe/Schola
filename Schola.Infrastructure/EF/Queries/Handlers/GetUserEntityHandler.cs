
using Schola.Infrastructure.EF.Contexts;
using Schola.Shared.Abstractions.Queries;
using Microsoft.EntityFrameworkCore;
using Schola.Infrastructure.EF.Models;

namespace Schola.Infrastructure.EF.Queries.Handlers;

internal sealed class GetUserEntityHandler : IQueryHandler<GetUserEntity, UserEntityDto>
{
    private readonly DbSet<UserReadModel> _UserEntities;

    public GetUserEntityHandler(ReadDbContext context)
        => _UserEntities = context.Users;
    public async Task<UserEntityDto> HandleAsync(GetUserEntity query)
    {
        return await _UserEntities
            .AsNoTracking()
            .Where(x => x.ID == query.Id)
            .Select(x => new UserEntityDto(
                x.ID,
                x.FullName,
                x.Email,
                x.Mobile
            ))
            .SingleAsync();
    }
}
