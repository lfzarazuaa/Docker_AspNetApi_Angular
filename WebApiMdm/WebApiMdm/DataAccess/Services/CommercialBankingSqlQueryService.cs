using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Utils.Directory;

namespace WebApiMdm.DataAccess.Services;
public class CommercialBankingSqlQueryService : SqlQueryService, ICommercialBankingSqlQueryService
{
    public CommercialBankingSqlQueryService() : base(DirectoryPath.CommercialBankingDataAccessDirectory){}
}
