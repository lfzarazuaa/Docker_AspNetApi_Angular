using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Utils.Directory;

namespace WebApiMdm.DataAccess.Services;
public class RetailBankingSqlQueryService : SqlQueryService, IRetailBankingSqlQueryService
{
    public RetailBankingSqlQueryService() : base(DirectoryPath.RetailBankingDataAccessDirectory){}
}
