using Dapper;
using System.Data;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.Dtos.Response.Utils;

namespace WebApiMdm.DataAccess.Repositories.CommercialBanking.UtilsDataAccessor;
public class UtilsRepository : Repository, IUtilsRepository
{
    public UtilsRepository(IDbConnection connection, ICommercialBankingSqlQueryService sqlQueryService) : base(connection, sqlQueryService, "UtilsDataAccessor", "UtilsQueries.sql")
    {
    }

    public string GetDatabaseVersion()
    {
        return _connection.QuerySingleOrDefault<string>(_queries["GetDatabaseVersion"]);
    }

    public IEnumerable<DatabaseTableDetailsResponse> GetDatabaseTables()
    {
        return _connection.Query<DatabaseTableDetailsResponse>(_queries["GetDatabaseTables"]);
    }
}
