﻿using AutoMapper;
using Shaker.Domain.Entities;
using Shaker.Domain.Models.AuthModels;
using Shaker.Domain.Models.ShakerOptionsModel;
using Shaker.Domain.Models.ShakersModel;
using Shaker.Domain.Models.UserModels;

namespace Shaker.Persistance.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<User, CreateUserModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();
        CreateMap<User, UserRegisterModel>().ReverseMap();
        #endregion

        #region Shakers
        CreateMap<Shakers, CreateShakersModel>().ReverseMap();
        #endregion

        #region ShakerOptions
        CreateMap<ShakerOptions, CreateShakerOptionsModel>().ReverseMap();
        CreateMap<ShakerOptions, UpdateShakerOptionsModel>().ReverseMap();  
        #endregion
    }
}
