using Microsoft.Data.SqlClient;
using System.Data;
using WebApiMdm.DataAccess.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public abstract class UnitOfWork : IUnitOfWork
{
    public IDbConnection Connection { get; }

    protected UnitOfWork(string connectionString)
    {
        Connection = new SqlConnection(connectionString);
    }

    public void Dispose()
    {
        Connection.Dispose();
    }
}
