using Shaker.Domain.Entities;

namespace Shaker.Domain.Repositories.UserRepositories;

public interface IUserCommandRepository
{
    Task CreateUser(User user);
    Task DeleteUser(int userId);
}
