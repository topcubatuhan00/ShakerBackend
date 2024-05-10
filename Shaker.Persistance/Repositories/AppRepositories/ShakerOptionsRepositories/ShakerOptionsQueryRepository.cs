using Microsoft.Data.SqlClient;
using Shaker.Domain.Entities;
using Shaker.Domain.Models.ShakerOptionsModel;
using Shaker.Domain.Repositories.ShakerOptionsRepositories;

namespace Shaker.Persistance.Repositories.AppRepositories.ShakerOptionsRepositories;

internal class ShakerOptionsQueryRepository : Repository, IShakerOptionsQueryRepository
{
    #region Ctor
    public ShakerOptionsQueryRepository
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
    public async Task<ShakerOptions> GetShakerOptions(int shakerOptionsId)
    {
        var command = CreateCommand("SELECT * FROM [ShakerOptions] WHERE Id=@id");
        command.Parameters.AddWithValue("@id", shakerOptionsId);

        using (var reader = command.ExecuteReader())
        {
            reader.Read();

            if (reader.HasRows)
            {
                return new ShakerOptions
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ShakerId = Convert.ToInt32(reader["ShakerId"]),
                    IsStoped = Convert.ToBoolean(reader["IsStoped"]),
                    RunningTime = Convert.ToInt32(reader["RunningTime"]),
                    StopedTime = Convert.ToDateTime(reader["StopedTime"])
                };
            }
            else
            {
                throw new Exception("Data Not Found");
            }
        }
    }

    public async Task<ShakerOptions> GetOptionsForUI(int shakerOptionsId)
    {
        var command = CreateCommand("SELECT TOP 1 * FROM [ShakerOptions] WHERE ShakerId=@id ORDER BY Id DESC");
        command.Parameters.AddWithValue("@id", shakerOptionsId);

        using (var reader = command.ExecuteReader())
        {
            reader.Read();

            if (reader.HasRows)
            {
                return new ShakerOptions
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ShakerId = Convert.ToInt32(reader["ShakerId"]),
                    IsStoped = Convert.ToBoolean(reader["IsStoped"]),
                    RunningTime = Convert.ToInt32(reader["RunningTime"]),
                    StopedTime = Convert.ToDateTime(reader["StopedTime"])
                };
            }
            else
            {
                throw new Exception("Data Not Found");
            }
        }
    }

    public async Task<int> GetLastId()
    {
        var command = CreateCommand("SELECT TOP 1 Id FROM [ShakerOptions] ORDER BY Id DESC");
        using (var reader = await command.ExecuteReaderAsync())
        {
            if (reader.Read())
            {
                return Convert.ToInt32(reader["Id"]);
            }
            else
            {
                throw new Exception("No rows found in ShakerOptions table.");
            }
        }
    }

    public async Task<IList<GetAllOptionsModel>> GetAll(int shakerId)
    {
        var shakersList = new List<GetAllOptionsModel>();

        var command = CreateCommand("SELECT * FROM [ShakerOptions] where ShakerId=@id and IsStoped=1");
        command.Parameters.AddWithValue("@id", shakerId);
        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var shaker = new GetAllOptionsModel
                {
                    StopedTime = Convert.ToDateTime(reader["StopedTime"]),
                    RunningTime = Convert.ToInt32(reader["RunningTime"])
                };

                shakersList.Add(shaker);
            }
        }
        return shakersList;
    }

    #endregion
}
