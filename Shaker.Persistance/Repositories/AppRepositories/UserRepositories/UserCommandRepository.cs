using Microsoft.Data.SqlClient;
using Shaker.Domain.Entities;
using Shaker.Domain.Repositories.UserRepositories;

namespace Shaker.Persistance.Repositories.AppRepositories.UserRepositories;

public class UserCommandRepository : Repository, IUserCommandRepository
{
    #region Ctor
    public UserCommandRepository(SqlConnection context, SqlTransaction transaction)
    {
        this._context = context;
        this._transaction = transaction;
    }
    #endregion

    #region Methods
    public async Task CreateUser(User user)
    {
        var query = "INSERT INTO [User]" +
            "(Name, LastName, UserName, Email, Password," +
            "CreatorName, CreatedDate, UpdaterName, UpdatedDate, DeleterName, DeletedDate)" +
            "VALUES" +
            "(@name, @lastname, @username, @email, @password" +
            "@creatorname, @createddate, @updatername, @updateddate, @deletername, @deleteddate);" +
            "SELECT SCOPE_IDENTITY();";

        var command = CreateCommand(query);
        command.Parameters.AddWithValue("@name", user.Name);
        command.Parameters.AddWithValue("@lastname", user.LastName);
        command.Parameters.AddWithValue("@username", user.UserName);
        command.Parameters.AddWithValue("@email", user.Email);
        command.Parameters.AddWithValue("@password", user.Password);

        command.Parameters.AddWithValue("@creatorname", user.CreatorName);
        command.Parameters.AddWithValue("@createddate", user.CreatedDate);
        command.Parameters.AddWithValue("@updatername", user.UpdaterName);
        command.Parameters.AddWithValue("@updateddate", user.UpdatedDate);
        command.Parameters.AddWithValue("@deletername", user.DeleterName);
        command.Parameters.AddWithValue("@deleteddate", user.DeletedDate);

        await command.ExecuteNonQueryAsync();
    }
    #endregion
}
