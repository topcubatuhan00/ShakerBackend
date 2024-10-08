﻿using Shaker.Domain.Models.UserModels;

namespace Shaker.Application.Services;

public interface IUserService
{
    Task CreateUser(CreateUserModel model);
    Task DeleteUser(int id);
    Task GetAllUsers();
    Task GetUser(int id);
}
