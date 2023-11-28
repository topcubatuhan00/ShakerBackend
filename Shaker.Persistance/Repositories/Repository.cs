using Microsoft.Data.SqlClient;

namespace Shaker.Persistance.Repositories;

public abstract class Repository
{
	#region Fields
	protected SqlConnection _context;
	protected SqlTransaction _transaction;
	#endregion

	#region Methods
	protected SqlCommand CreateCommand(string query)
	{
		return new SqlCommand(query, _context, _transaction);
	}
	#endregion
}
