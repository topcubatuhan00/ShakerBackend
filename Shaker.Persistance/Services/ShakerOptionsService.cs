using AutoMapper;
using Shaker.Application.Services;
using Shaker.Domain.Entities;
using Shaker.Domain.Models.ShakerOptionsModel;
using Shaker.Domain.UnitOfWork;

namespace Shaker.Persistance.Services
{
    public class ShakerOptionsService : IShakerOptionsService
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private Timer? _timer;
        private int _stopedShakerId = 0;
        #endregion

        #region Ctor
        public ShakerOptionsService
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
        public async Task CreateShakerOptions(CreateShakerOptionsModel model)
        {
            using (var context = _unitOfWork.Create())
            {
                
                var entity = _mapper.Map<ShakerOptions>(model);
                if (entity.RunningTime > 0)
                {
                    entity.StopedTime = DateTime.Now.AddMinutes(entity.RunningTime);

                    await context.Repositories.shakerOptionsCommandRepository.CreateShaker(entity);
                    ChangeStatusOne(entity.ShakerId);
                    context.SaveChanges();
                    var generatedId = await GetLastShakerOptionsId();
                    // Her ShakerOptions için ayrı bir Timer oluştur
                    Timer timer = new Timer((state) =>
                    {
                        Task.Run(void () => ChangeStatusZero(entity.ShakerId, generatedId));
                    }, null, entity.RunningTime * 60000, Timeout.Infinite);
                }
                else
                {
                    await context.Repositories.shakerOptionsCommandRepository.CreateShaker(entity);
                    ChangeStatusOne(entity.ShakerId);
                    context.SaveChanges();
                }
            }
        }

        private async Task StopShaker(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var shaker = await context.Repositories.shakerOptionsQueryRepository.GetShakerOptions(id);
                shaker.IsStoped = true;
                shaker.RunningTime = 0;
                await context.Repositories.shakerOptionsCommandRepository.UpdateShakerOptions(shaker);
                context.SaveChanges();
            }
        }

        private async Task<int> GetLastShakerOptionsId()
        {
            using (var context = _unitOfWork.Create())
            {
                var lastId = await context.Repositories.shakerOptionsQueryRepository.GetLastId();
                return lastId;
            }
        }

        private async void ChangeStatusZero(int shakerId, int optionsId)
        {
            using (var context = _unitOfWork.Create())
            {
                await context.Repositories.shakerOptionsCommandRepository.UpdateShakerStatusZero(shakerId);
                context.SaveChanges();
                await StopShaker(optionsId);
            }
        }
        private async void ChangeStatusOne(int shakerId)
        {
            using (var context = _unitOfWork.Create())
            {
                await context.Repositories.shakerOptionsCommandRepository.UpdateShakerStatusOne(shakerId);
                context.SaveChanges();
            }
        }

        public Task DeleteShakerOptions(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ShakerOptions> GetShakerOptions(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                var res = await context.Repositories.shakerOptionsQueryRepository.GetShakerOptions(id);
                return res;
            }
        }

        public async Task UpdateShakerOptions(UpdateShakerOptionsModel model)
        {
            using (var context = _unitOfWork.Create())
            {
                var entity = _mapper.Map<ShakerOptions>(model);
                await context.Repositories.shakerOptionsCommandRepository.UpdateShakerOptions(entity);
                context.SaveChanges();
            }
        }
        #endregion
    }
}
