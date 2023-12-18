using Shaker.Domain.Entities;
using Shaker.Domain.Models.ShakersModel;

namespace Shaker.Application.Services;

public interface IShakersService
{
    Task CreateShaker(CreateShakersModel model);
    Task DeleteShaker(int id);
    Task<IList<Shakers>> GetAllShakers();
    Task<Shakers> GetShaker(int id);
}
