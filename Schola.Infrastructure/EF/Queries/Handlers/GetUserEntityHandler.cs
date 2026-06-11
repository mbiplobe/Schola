
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
        try
        {
            var result = await _UserEntities
                .AsNoTracking()
                .Where(x => x.ID == query.Id && x.IsActive == true)
                .FirstOrDefaultAsync();

            if (result == null)
            {
                throw new KeyNotFoundException($"User with ID {query.Id} not found.");
            }

            return result.AsDto();
        }
        catch (Exception ex)
        {
            // Log the exception (not implemented here)
            throw new Exception($"Error fetching user with ID {query.Id}: {ex.Message}");
        }
    }
}
