using Shaker.Domain.Entities;

namespace Shaker.Domain.Repositories.UserRepositories;

public interface IUserQueryRepository
{
    Task<bool> UserNameIsExist(string userName);
    Task<User> GetByUserName(string userName);
    Task<bool> UserIdIsExist(int id);
    Task<bool> PasswordVerify(string userName, string password);
}
