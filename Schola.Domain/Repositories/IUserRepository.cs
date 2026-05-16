

namespace Schola.Domain.Repositories;

public interface IUserRepository
{
    Task<UserEntity> GetAsync(EntityID id);

    Task<UserEntity> GetUserIdAsync(string userName);
    Task AddAsync(UserEntity userEntity);
    Task UpdateAsync(UserEntity userEntity);
    Task DeleteAsync(UserEntity userEntity);
}
