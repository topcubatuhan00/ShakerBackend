﻿using AutoMapper;
using Shaker.Application.Services;
using Shaker.Domain.Entities;
using Shaker.Domain.Models.UserModels;
using Shaker.Domain.UnitOfWork;

namespace Shaker.Persistance.Services;

public class UserService : IUserService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public UserService
    (
        IMapper mapper,
        IUnitOfWork unitOfWork
    )
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    #endregion

    #region Methods
    public async Task CreateUser(CreateUserModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.userQueryRepository.UserNameIsExist(model.UserName);
            if (check) throw new Exception("user already exist");

            var entity = _mapper.Map<User>(model);
            await context.Repositories.userCommandRepository.CreateUser(entity);
            context.SaveChanges();
        }
    }
    #endregion

}
