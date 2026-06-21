// using Microsoft.EntityFrameworkCore;
// using Schola.Infrastructure.EF.Contexts;

// internal sealed class SectionRepository : ISectionRepository
// {
//     private readonly DbSet<SectionEntity> _sectionEntities;
//     private readonly WriteDbContext _writeDbContext;

//     public SectionRepository(WriteDbContext writeDbContext)
//     {
//         _writeDbContext = writeDbContext;
//         _sectionEntities = writeDbContext.Sections;
//     }

//     public Task<SectionEntity?> GetAsync(long id)
//         => _sectionEntities.SingleOrDefaultAsync(x => x.Id == id);

//     public async Task AddAsync(SectionEntity sectionEntity)
//     {
//         await _sectionEntities.AddAsync(sectionEntity);
//         await _writeDbContext.SaveChangesAsync();
//     }

//     public async Task UpdateAsync(SectionEntity sectionEntity)
//     {
//         _sectionEntities.Update(sectionEntity);
//         await _writeDbContext.SaveChangesAsync();
//     }

//     public async Task DeleteAsync(SectionEntity sectionEntity)
//     {
//         _sectionEntities.Remove(sectionEntity);
//         await _writeDbContext.SaveChangesAsync();
//     }
// }