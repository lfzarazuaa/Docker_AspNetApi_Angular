namespace WebApiMdm.DataAccess.Services.Interfaces;

public interface ISqlQueryService
{
    Dictionary<string, string> ParseSqlFile(params string[] path);
}

