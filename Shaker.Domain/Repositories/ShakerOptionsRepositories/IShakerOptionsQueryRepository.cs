using Shaker.Domain.Entities;

namespace Shaker.Domain.Repositories.ShakerOptionsRepositories;

public interface IShakerOptionsQueryRepository
{
    Task<ShakerOptions> GetShakerOptions(int shakerOptionsId);
    Task<int> GetLastId();
}
