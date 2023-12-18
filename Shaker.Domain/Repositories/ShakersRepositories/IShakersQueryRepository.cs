using Shaker.Domain.Entities;

namespace Shaker.Domain.Repositories.ShakersRepositories;

public interface IShakersQueryRepository
{
    Task<IList<Shakers>> GetAllShakers();
    Task<Shakers> GetShaker(int shakerId);
}
