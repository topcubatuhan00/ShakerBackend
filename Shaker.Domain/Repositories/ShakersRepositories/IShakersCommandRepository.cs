using Shaker.Domain.Entities;
namespace Shaker.Domain.Repositories.ShakersRepositories;

public interface IShakersCommandRepository
{
    Task CreateShaker(Shakers shakers);
    Task DeleteShaker(int shakerId);
}
