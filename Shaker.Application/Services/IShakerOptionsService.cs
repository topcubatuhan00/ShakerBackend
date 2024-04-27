using Shaker.Domain.Entities;
using Shaker.Domain.Models.ShakerOptionsModel;

namespace Shaker.Application.Services;

public interface IShakerOptionsService
{
    Task CreateShakerOptions(CreateShakerOptionsModel model);
    Task UpdateShakerOptions(UpdateShakerOptionsModel model);
    Task DeleteShakerOptions(int id);
    Task<ShakerOptions> GetShakerOptions(int id);
}
