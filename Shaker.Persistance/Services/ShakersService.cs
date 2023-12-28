using AutoMapper;
using Shaker.Application.Services;
using Shaker.Domain.Entities;
using Shaker.Domain.Models.ShakersModel;
using Shaker.Domain.UnitOfWork;

namespace Shaker.Persistance.Services;

public class ShakersService : IShakersService
{
    #region Fields
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    #endregion

    #region Ctor
    public ShakersService
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
    public async Task CreateShaker(CreateShakersModel model)
    {
        using (var context = _unitOfWork.Create())
        {
            var entity = _mapper.Map<Shakers>(model);
            await context.Repositories.shakersCommandRepository.CreateShaker(entity);
            context.SaveChanges();
        }
    }

    public async Task DeleteShaker(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var check = await context.Repositories.shakersQueryRepository.GetShaker(id);
            if (check == null) throw new Exception("Shaker Not Found");

            await context.Repositories.shakersCommandRepository.DeleteShaker(id);
            context.SaveChanges();
        }
    }

    public async Task<IList<Shakers>> GetAllShakers()
    {
        using (var context = _unitOfWork.Create())
        {
            var res = await context.Repositories.shakersQueryRepository.GetAllShakers();
            return res;
        }
    }

    public async Task<Shakers> GetShaker(int id)
    {
        using (var context = _unitOfWork.Create())
        {
            var res = await context.Repositories.shakersQueryRepository.GetShaker(id);
            return res;
        }
    }
    #endregion
}
