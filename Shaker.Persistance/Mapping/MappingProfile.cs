using AutoMapper;
using Shaker.Domain.Entities;
using Shaker.Domain.Models.UserModels;

namespace Shaker.Persistance.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region User
        CreateMap<User, CreateUserModel>().ReverseMap();
        CreateMap<User, UpdateUserModel>().ReverseMap();
        #endregion
    }
}
