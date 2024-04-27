using AutoMapper;
using Shaker.Application.Services;
using Shaker.Domain.Entities;
using Shaker.Domain.Models.ShakerOptionsModel;
using Shaker.Domain.UnitOfWork;
using System.ComponentModel;

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
                    context.SaveChanges();
                    var generatedId = await GetLastShakerOptionsId();
                    // Her ShakerOptions için ayrı bir Timer oluştur
                    Timer timer = new Timer((state) =>
                    {
                        Task.Run(async () => await StopShaker(generatedId));
                    }, null, entity.RunningTime * 60000, Timeout.Infinite);
                }
                else
                {
                    await context.Repositories.shakerOptionsCommandRepository.CreateShaker(entity);
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
                ChangeStatus(shaker.ShakerId);
            }

            Console.WriteLine($"Shaker {id} stopped!");
        }

        private async Task<int> GetLastShakerOptionsId()
        {
            using (var context = _unitOfWork.Create())
            {
                var lastId = await context.Repositories.shakerOptionsQueryRepository.GetLastId();
                return lastId;
            }
        }

        private void ChangeStatus(int shakerId)
        {
            using (var context = _unitOfWork.Create())
            {
                context.Repositories.shakerOptionsCommandRepository.UpdateShakerStatus(shakerId);
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
