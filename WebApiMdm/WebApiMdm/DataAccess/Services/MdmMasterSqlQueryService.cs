using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Utils.Directory;

namespace WebApiMdm.DataAccess.Services;
public class MdmMasterSqlQueryService : SqlQueryService, IMdmMasterSqlQueryService
{
    public MdmMasterSqlQueryService() : base(DirectoryPath.MdmMasterDataAccessDirectory){}
}
