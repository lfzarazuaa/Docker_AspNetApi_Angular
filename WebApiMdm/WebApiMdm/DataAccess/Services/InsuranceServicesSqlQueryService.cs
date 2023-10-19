using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Utils.Directory;

namespace WebApiMdm.DataAccess.Services;
public class InsuranceServicesSqlQueryService : SqlQueryService, IInsuranceServicesSqlQueryService
{
    public InsuranceServicesSqlQueryService() : base(DirectoryPath.InsuranceServicesDataAccessDirectory) { }
}
