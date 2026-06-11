public interface ICRUDRepository<T,F>
{
    Task<T> GetAsync(F id);

    Task AddAsync(T sectionEntity);
    Task UpdateAsync(T sectionEntity);
    Task DeleteAsync(T sectionEntity);
}