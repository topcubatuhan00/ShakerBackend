using Shaker.Domain.Entities;

namespace Shaker.Domain.Repositories.ShakerOptionsRepositories;

public interface IShakerOptionsCommandRepository
{
    Task CreateShaker(ShakerOptions shakerOptions);
    Task UpdateShakerOptions(ShakerOptions shakerOptions);
    Task UpdateShakerStatus(int id);
}
