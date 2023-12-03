using Shaker.Domain.Repositories.UserRepositories;

namespace Shaker.Domain.UnitOfWork;

public interface IUnitOfWorkRepository
{
    #region User
    IUserCommandRepository userCommandRepository { get; }
    IUserQueryRepository userQueryRepository { get; }
    #endregion
}
