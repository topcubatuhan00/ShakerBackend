using Shaker.Domain.Entities;
using Shaker.Domain.Models.UserModels;

namespace Shaker.Domain.Repositories.UserRepositories;

public interface IUserCommandRepository
{
    Task CreateUser(User user);
    Task DeleteUser(int userId);
}
