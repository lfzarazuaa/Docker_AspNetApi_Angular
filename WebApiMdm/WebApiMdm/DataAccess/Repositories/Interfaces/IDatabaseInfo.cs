using WebApiMdm.Models.Dtos.Response.Utils;

namespace WebApiMdm.DataAccess.Repositories.Interfaces;
public interface IDatabaseInfo
{
    string GetDatabaseVersion();
    IEnumerable<DatabaseTableDetailsResponse> GetDatabaseTables();
}
