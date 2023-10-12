using WebApiMdm.DataAccess.Connection.InsurancesServices;
using WebApiMdm.DataAccess.Repositories.InsurancesServices.UtilsDataAccessor;
using WebApiMdm.DataAccess.Services;
using WebApiMdm.DataAccess.Services.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class InsurancesServicesUnitOfWork : UnitOfWork
{
    private readonly IInsurancesServicesSqlQueryService _insurancesservicesSqlQueryService;
    
    public InsurancesServicesUnitOfWork(InsurancesServicesDbConfig config, IInsurancesServicesSqlQueryService sqlQueryService) : base(config.ConnectionString??"")

    {
        _insurancesservicesSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _insurancesservicesSqlQueryService);
    //public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _insurancesservicesSqlQueryService);
}
