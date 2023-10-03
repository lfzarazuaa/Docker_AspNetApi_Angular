using System.Data;
using WebApiMdm.DataAccess.Services.Interfaces;

namespace WebApiMdm.DataAccess.Repositories;

public abstract class Repository
{
    protected readonly IDbConnection _connection;
    protected Dictionary<string, string> _queries { get; init; }

    public Repository(IDbConnection connection, ISqlQueryService sqlQueryService, params string[] path)
    {
        _connection = connection;
        _queries = sqlQueryService.ParseSqlFile(path);
    }
}

