public interface IClassRepository
{
    Task<ClassEntity> GetAsync(long id);

    Task AddAsync(ClassEntity classEntity);
    Task UpdateAsync(ClassEntity classEntity);
    Task DeleteAsync(ClassEntity classEntity);
}