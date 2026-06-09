using Microsoft.EntityFrameworkCore;
using Schola.Infrastructure.EF.Contexts;

internal sealed class ClassEntityRepository : IClassRepository
{
    private readonly DbSet<ClassEntity> _classEntities;
    private readonly WriteDbContext _writeDbContext;

    public ClassEntityRepository(WriteDbContext writeDbContext)
    {
        _classEntities = writeDbContext.Classes;
        _writeDbContext = writeDbContext;
    }

   public Task<ClassEntity?> GetAsync(long id)
    => _classEntities.SingleOrDefaultAsync(pl => pl.Id == id);

    public async Task AddAsync(ClassEntity classEntity)
    {
        await _classEntities.AddAsync(classEntity);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task UpdateAsync(ClassEntity classEntity)
    {
        _classEntities.Update(classEntity);
        await _writeDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(ClassEntity classEntity)
    {
        _classEntities.Remove(classEntity);
        await _writeDbContext.SaveChangesAsync();
    }


}

