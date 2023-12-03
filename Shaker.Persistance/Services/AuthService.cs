using AutoMapper;
using Shaker.Application.Services;
using Shaker.Application.Services.Utilities;
using Shaker.Domain.Entities;
using Shaker.Domain.Models.AuthModels;
using Shaker.Domain.UnitOfWork;

namespace Shaker.Persistance.Services;

public class AuthService : IAuthService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IJwtService _jwtService;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public AuthService
    (
        IMapper mapper,
        IJwtService jwtService,
        IUnitOfWork unitOfWork
    )
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _jwtService = jwtService;
    }
    #endregion

    #region Methods
    public Task<bool> CheckUserName(string userName)
    {
        using (var context = _unitOfWork.Create())
        {
            var res = context.Repositories.userQueryRepository.UserNameIsExist(userName);
            return res;
        }
    }

    public Task<User> GetByUserName(string userName)
    {
        using (var context = _unitOfWork.Create())
        {
            var res = context.Repositories.userQueryRepository.GetByUserName(userName);
            return res;
        }
    }

    public async Task<string> Login(UserLoginModel model)
    {
        var user = await GetByUserName(model.UserName);
        if (user == null) throw new Exception("User not found");

        var verifyPass = VerifyPassword(model.Password, user.Password);
        if (!verifyPass) throw new Exception("Password Incorrect");

        return _jwtService.CreateToken(user);
    }

    public async Task Register(UserRegisterModel model)
    {
        model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

        if (await UserIsExist(model.UserName)) throw new Exception("User Already Registered");

        using (var context = _unitOfWork.Create())
        {
            var user = _mapper.Map<User>(model);
            await context.Repositories.userCommandRepository.CreateUser(user);
            context.SaveChanges();
        }
    }

    #endregion

    #region Helpers
    private bool VerifyPassword(string Password, string PasswordHash)
    {
        if (!BCrypt.Net.BCrypt.Verify(Password, PasswordHash)) return false;
        return true;
    }

    private async Task<bool> UserIsExist(string userName)
    {
        using (var context = _unitOfWork.Create())
        {
            var result = await context.Repositories.userQueryRepository.UserNameIsExist(userName);
            if (result) return true;
            return false;
        }
    }
    #endregion

}
