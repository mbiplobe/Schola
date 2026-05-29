using Schola.Application.Services;
using Schola.Infrastructure.EF.Contexts;
using Schola.Infrastructure.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace Schola.Infrastructure.EF.Services;

internal sealed class UserEntityReadService : IUserEntityReadService
{
    private readonly DbSet<UserReadModel> _userEntity;

    public UserEntityReadService(ReadDbContext context)
        => _userEntity = context.Users;

    public Task<bool> ExistsByNameAsync(string name)
        => _userEntity.AnyAsync(pl => pl.FullName == name);
}
