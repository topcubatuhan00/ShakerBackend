using Microsoft.Data.SqlClient;
using Shaker.Domain.Entities;
using Shaker.Domain.Repositories.ShakersRepositories;

namespace Shaker.Persistance.Repositories.AppRepositories.ShakersRepositories;

public class ShakersCommandRepository : Repository, IShakersCommandRepository
{
    #region Ctor
    public ShakersCommandRepository
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

    public async Task CreateShaker(Shakers shakers)
    {
        var query = "INSERT INTO [Shakers]" +
            "(ShakerName, BuildingName, FloorCount, RoomName, ShakerOptionsId, Status," +
            "CreatorName, CreatedDate, UpdaterName, UpdatedDate, DeleterName, DeletedDate)" +
            "VALUES" +
            "(@shakerName, @buildingName, @floorCount, @roomName, @shakerOptionsId, @status," +
            "@creatorname, @createddate, @updatername, @updateddate, @deletername, @deleteddate);" +
            "SELECT SCOPE_IDENTITY();";

        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@shakerName", shakers.ShakerName);
        command.Parameters.AddWithValue("@buildingName", shakers.BuildingName);
        command.Parameters.AddWithValue("@floorCount", shakers.FloorCount);
        command.Parameters.AddWithValue("@roomName", shakers.RoomName);
        command.Parameters.AddWithValue("@shakerOptionsId", shakers.ShakerOptionsId);
        command.Parameters.AddWithValue("@status", shakers.Status);

        command.Parameters.AddWithValue("@creatorname", shakers.CreatorName);
        command.Parameters.AddWithValue("@createddate", shakers.CreatedDate);
        command.Parameters.AddWithValue("@updatername", DBNull.Value);
        command.Parameters.AddWithValue("@updateddate", DBNull.Value);
        command.Parameters.AddWithValue("@deletername", DBNull.Value);
        command.Parameters.AddWithValue("@deleteddate", DBNull.Value);

        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteShaker(int shakerId)
    {
        var query = "DELETE FROM [Shakers] WHERE Id=@id";
        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@id", shakerId);

        await command.ExecuteNonQueryAsync();
    }
    #endregion
}
