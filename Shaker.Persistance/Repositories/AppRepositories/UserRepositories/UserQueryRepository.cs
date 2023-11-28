using Microsoft.Data.SqlClient;
using Shaker.Domain.Entities;
using Shaker.Domain.Repositories.UserRepositories;

namespace Shaker.Persistance.Repositories.AppRepositories.UserRepositories;

public class UserQueryRepository : Repository, IUserQueryRepository
{
    #region Ctor
    public UserQueryRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task<bool> UserNameIsExist(string userName)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [User] WHERE UserName = @username");

        command.Parameters.AddWithValue("@username", userName);
        var result = await command.ExecuteScalarAsync();

        int count;
        if (int.TryParse(result?.ToString(), out count))
            return count > 0;

        return false;

    }

    public async Task<bool> UserIdIsExist(int id)
    {
        var command = CreateCommand("SELECT COUNT(*) FROM [User] WHERE Id = @id");

        command.Parameters.AddWithValue("@id", id);
        var result = await command.ExecuteScalarAsync();

        int count;
        if (int.TryParse(result?.ToString(), out count))
            return count > 0;

        return false;

    }

    public async Task<bool> PasswordVerify(string userName, string password)
    {
        var command = CreateCommand("SELECT * FROM [User] WHERE UserName = @username");
        command.Parameters.AddWithValue("@username", userName);
        bool flag = false;

        using (var reader = await command.ExecuteReaderAsync())
        {
            if (await reader.ReadAsync())
            {
                if (password == reader["Password"].ToString())
                    flag = true;
            }
            reader.Close();
        }
        return flag;
    }

    public async Task<User> GetByUserName(string userName)
    {
        var command = CreateCommand("SELECT * FROM [User] WHERE UserName = @userName");
        command.Parameters.AddWithValue("@userName", userName);

        using (var reader = command.ExecuteReader())
        {
            reader.Read();

            return new User
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"] != DBNull.Value ? reader["Name"].ToString() : string.Empty,
                LastName = reader["LastName"] != DBNull.Value ? reader["LastName"].ToString() : string.Empty,
                UserName = reader["UserName"] != DBNull.Value ? reader["UserName"].ToString() : string.Empty,
                Password = reader["Password"] != DBNull.Value ? reader["Password"].ToString() : string.Empty,
                Email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty
            };
        }
    }
    #endregion
}
