using Microsoft.Data.SqlClient;
using Shaker.Domain.Entities;
using Shaker.Domain.Repositories.ShakersRepositories;

namespace Shaker.Persistance.Repositories.AppRepositories.ShakersRepositories;

public class ShakersQueryRepository : Repository, IShakersQueryRepository
{
    #region Ctor
    public ShakersQueryRepository
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
    public async Task<IList<Shakers>> GetAllShakers()
    {
        var shakersList = new List<Shakers>(); // Shakers tipinde bir liste oluşturuyoruz

        var command = CreateCommand("SELECT * FROM [Shakers]");

        using (var reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var shaker = new Shakers
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    ShakerName = reader["ShakerName"] != DBNull.Value ? reader["ShakerName"].ToString() : string.Empty,
                    BuildingName = reader["BuildingName"] != DBNull.Value ? reader["BuildingName"].ToString() : string.Empty,
                    FloorCount = reader["FloorCount"] != DBNull.Value ? Convert.ToInt32(reader["FloorCount"]) : -1,
                    RoomName = reader["RoomName"] != DBNull.Value ? reader["RoomName"].ToString() : string.Empty,
                    ShakerOptionsId = reader["ShakerOptionsId"] != DBNull.Value ? Convert.ToInt32(reader["ShakerOptionsId"]) : -1,
                    Status = Convert.ToBoolean(reader["Status"])
                };

                shakersList.Add(shaker);
            }
        }

        return shakersList;
    }

    public async Task<Shakers> GetShaker(int shakerId)
    {
        var command = CreateCommand("SELECT * FROM [Shakers] WHERE Id= @id");
        command.Parameters.AddWithValue("@Id", shakerId);

        using (var reader = command.ExecuteReader())
        {
            reader.Read();

            return new Shakers
            {
                Id = Convert.ToInt32(reader["Id"]),
                ShakerName = reader["ShakerName"] != DBNull.Value ? reader["ShakerName"].ToString() : string.Empty,
                BuildingName = reader["BuildingName"] != DBNull.Value ? reader["BuildingName"].ToString() : string.Empty,
                FloorCount = reader["FloorCount"] != DBNull.Value ? Convert.ToInt32(reader["FloorCount"]) : -1,
                RoomName = reader["RoomName"] != DBNull.Value ? reader["RoomName"].ToString() : string.Empty,
                ShakerOptionsId = reader["ShakerOptionsId"] != DBNull.Value ? Convert.ToInt32(reader["ShakerOptionsId"]) : -1,
                Status = Convert.ToBoolean(reader["Status"])
            };
        }
    }
    #endregion
}
