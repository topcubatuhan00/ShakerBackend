using Shaker.Domain.Models.AuthModels;

namespace Shaker.Application.Services;

public interface IAuthService
{
    Task<bool> CheckUserName(string userName);
    Task Register(UserRegisterModel model);
    Task<string> Login(UserLoginModel model);
}
