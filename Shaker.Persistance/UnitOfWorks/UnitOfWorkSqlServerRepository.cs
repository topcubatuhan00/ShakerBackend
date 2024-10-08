﻿using Microsoft.Data.SqlClient;
using Shaker.Domain.Repositories.ShakerOptionsRepositories;
using Shaker.Domain.Repositories.ShakersRepositories;
using Shaker.Domain.Repositories.UserRepositories;
using Shaker.Domain.UnitOfWork;
using Shaker.Persistance.Repositories.AppRepositories.ShakerOptionsRepositories;
using Shaker.Persistance.Repositories.AppRepositories.ShakersRepositories;
using Shaker.Persistance.Repositories.AppRepositories.UserRepositories;

namespace Shaker.Persistance.UnitOfWorks;

public class UnitOfWorkSqlServerRepository : IUnitOfWorkRepository
{
    #region Fields

    #region UserFields
    public IUserCommandRepository userCommandRepository { get; }
    public IUserQueryRepository userQueryRepository { get; }
    #endregion

    #region ShakerFileds

    public IShakersCommandRepository shakersCommandRepository { get; }

    public IShakersQueryRepository shakersQueryRepository { get; }
    #endregion

    #region ShakerOptionsFields
    public IShakerOptionsCommandRepository shakerOptionsCommandRepository { get; }
    public IShakerOptionsQueryRepository shakerOptionsQueryRepository { get; }
    #endregion

    #endregion

    #region Ctor
    public UnitOfWorkSqlServerRepository
    (
        SqlConnection context,
        SqlTransaction transaction
    )
    {
        #region User
        userCommandRepository = new UserCommandRepository(context, transaction);
        userQueryRepository = new UserQueryRepository(context, transaction);
        #endregion

        #region Shaker
        shakersCommandRepository = new ShakersCommandRepository(context, transaction);
        shakersQueryRepository = new ShakersQueryRepository(context, transaction);
        #endregion

        #region ShakerOptions
        shakerOptionsCommandRepository = new ShakerOptionsCommandRepository(context, transaction);
        shakerOptionsQueryRepository = new ShakerOptionsQueryRepository(context, transaction);
        #endregion
    }
    #endregion

}
