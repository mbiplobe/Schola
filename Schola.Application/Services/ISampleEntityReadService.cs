namespace Schola.Application.Services;

public interface IUserEntityReadService
{
    Task<bool> ExistsByNameAsync(string name);
}
