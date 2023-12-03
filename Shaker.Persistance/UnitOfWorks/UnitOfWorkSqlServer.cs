using Microsoft.Extensions.Configuration;
using Shaker.Domain.UnitOfWork;

namespace Shaker.Persistance.UnitOfWorks;

public class UnitOfWorkSqlServer : IUnitOfWork
{
    #region Fields
    private readonly IConfiguration _configuration;
    #endregion

    #region Ctor
    public UnitOfWorkSqlServer
    (
        IConfiguration configuration
    )
    {
        _configuration = configuration;
    }
    #endregion

    #region Methods
    public IUnitOfWorkAdapter Create()
    {
        var connectionString = GetConnectionString();
        return new UnitOfWorkSqlServerAdapter(connectionString);
    }

    public string GetConnectionString()
    {
        return _configuration.GetConnectionString("ShakerConnection");
    }
    #endregion
}
