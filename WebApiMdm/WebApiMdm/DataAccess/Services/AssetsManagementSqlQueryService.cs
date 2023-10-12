using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Utils.Directory;

namespace WebApiMdm.DataAccess.Services;
public class AssetsManagementSqlQueryService : SqlQueryService, IAssetsManagementSqlQueryService
{
    public AssetsManagementSqlQueryService() : base(DirectoryPath.AssetsManagementDataAccessDirectory){}
}
