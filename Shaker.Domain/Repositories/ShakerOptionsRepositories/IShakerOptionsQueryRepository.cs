using Shaker.Domain.Entities;
using Shaker.Domain.Models.ShakerOptionsModel;

namespace Shaker.Domain.Repositories.ShakerOptionsRepositories;

public interface IShakerOptionsQueryRepository
{
    Task<ShakerOptions> GetShakerOptions(int shakerOptionsId);
    Task<ShakerOptions> GetOptionsForUI(int shakerOptionsId);
    Task<IList<GetAllOptionsModel>> GetAll(int shakerId);
    Task<int> GetLastId();
}
