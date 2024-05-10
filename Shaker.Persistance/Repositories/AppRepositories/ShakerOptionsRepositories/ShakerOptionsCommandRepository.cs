using Microsoft.Data.SqlClient;
using Shaker.Domain.Entities;
using Shaker.Domain.Repositories.ShakerOptionsRepositories;

namespace Shaker.Persistance.Repositories.AppRepositories.ShakerOptionsRepositories;

public class ShakerOptionsCommandRepository : Repository, IShakerOptionsCommandRepository
{
    #region Ctor
    public ShakerOptionsCommandRepository
    (
        SqlConnection context,
        SqlTransaction transaction
    )
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task CreateShaker(ShakerOptions shakerOptions)
    {
        var query = "INSERT INTO [ShakerOptions]" +
            "(RunningTime, IsStoped, StopedTime, ShakerId)" +
            "VALUES" +
            "(@rnTime, @isStoped, @stTime, @skrId);" +
            "SELECT SCOPE_IDENTITY();";

        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@rnTime", shakerOptions.RunningTime);
        command.Parameters.AddWithValue("@isStoped", shakerOptions.IsStoped);
        command.Parameters.AddWithValue("@stTime", shakerOptions.StopedTime);
        command.Parameters.AddWithValue("@skrId", shakerOptions.ShakerId);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateShakerOptions(ShakerOptions shakerOptions)
    {
        var query = "update [ShakerOptions] set RunningTime=@time, IsStoped=@isSpd, StopedTime=@stpTime, ShakerId=@shid where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@time", shakerOptions.RunningTime);
        command.Parameters.AddWithValue("@isSpd", shakerOptions.IsStoped);
        command.Parameters.AddWithValue("@stpTime", shakerOptions.StopedTime);
        command.Parameters.AddWithValue("@shid", shakerOptions.ShakerId);
        command.Parameters.AddWithValue("@id", shakerOptions.Id);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateShakerStatusZero(int id)
    {
        var query = "update [Shakers] set Status=0 where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", id);

        await command.ExecuteNonQueryAsync();
    }

    public async Task UpdateShakerStatusOne(int id)
    {
        var query = "update [Shakers] set Status=1 where Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", id);

        await command.ExecuteNonQueryAsync();
    }

    public async Task RemoveShakerOptions(int id)
    {
        var query = "Delete from [ShakerOptions] where ShakerId=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", id);

        await command.ExecuteNonQueryAsync();
    }
    #endregion
}
