
using Microsoft.EntityFrameworkCore;
using Schola.Infrastructure.EF.Contexts;
using Schola.Infrastructure.EF.Models;

internal sealed class ClassReadService : IClassReadService
{
    private readonly DbSet<ClassReadModel> _classEntity;

    public ClassReadService(ReadDbContext context)
        => _classEntity = context.Classes;

   public async Task<bool> ExistsByNameAsync(string name)
       => await _classEntity.AnyAsync(x => x.Name == name);
}