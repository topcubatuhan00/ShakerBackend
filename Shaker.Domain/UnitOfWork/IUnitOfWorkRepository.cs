using Shaker.Domain.Repositories.ShakerOptionsRepositories;
using Shaker.Domain.Repositories.ShakersRepositories;
using Shaker.Domain.Repositories.UserRepositories;

namespace Shaker.Domain.UnitOfWork;

public interface IUnitOfWorkRepository
{
    #region User
    IUserCommandRepository userCommandRepository { get; }
    IUserQueryRepository userQueryRepository { get; }
    #endregion

    #region Shakers
    IShakersCommandRepository shakersCommandRepository { get; }
    IShakersQueryRepository shakersQueryRepository { get; }
    #endregion

    #region ShakerOptions
    IShakerOptionsCommandRepository shakerOptionsCommandRepository { get; }
    IShakerOptionsQueryRepository shakerOptionsQueryRepository { get; }
    #endregion
}
