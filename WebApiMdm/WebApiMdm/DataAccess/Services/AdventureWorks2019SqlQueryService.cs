using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Utils.Directory;

namespace WebApiMdm.DataAccess.Services;
public class AdventureWorks2019SqlQueryService : SqlQueryService, IAdventureWorks2019SqlQueryService
{
    public AdventureWorks2019SqlQueryService() : base(DirectoryPath.AdventureWorks2019DataAccessDirectory){}
}