using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Utils.Directory;

namespace WebApiMdm.DataAccess.Services;
public class InsurancesServicesSqlQueryService : SqlQueryService, IInsurancesServicesSqlQueryService
{
    public InsurancesServicesSqlQueryService() : base(DirectoryPath.InsurancesServicesDataAccessDirectory){}
}
