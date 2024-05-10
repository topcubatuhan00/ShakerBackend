using Shaker.Domain.Entities;

namespace Shaker.Domain.Repositories.ShakerOptionsRepositories;

public interface IShakerOptionsCommandRepository
{
    Task CreateShaker(ShakerOptions shakerOptions);
    Task UpdateShakerOptions(ShakerOptions shakerOptions);
    Task UpdateShakerStatusZero(int id);
    Task UpdateShakerStatusOne(int id);
    Task RemoveShakerOptions(int id);
}
