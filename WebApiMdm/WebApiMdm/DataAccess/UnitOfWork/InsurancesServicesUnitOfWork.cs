using WebApiMdm.DataAccess.Connection.InsuranceServices;
using WebApiMdm.DataAccess.Repositories.InsuranceServices.CustomerDataAccessor;
using WebApiMdm.DataAccess.Repositories.InsuranceServices.UtilsDataAccessor;
using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.DataAccess.UnitOfWork.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class InsuranceServicesUnitOfWork : UnitOfWork, ICustomerUnitOfWork
{
    private readonly IInsuranceServicesSqlQueryService _InsuranceServicesSqlQueryService;

    public InsuranceServicesUnitOfWork(InsuranceServicesDbConfig config, IInsuranceServicesSqlQueryService sqlQueryService) : base(config.ConnectionString ?? string.Empty)

    {
        _InsuranceServicesSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _InsuranceServicesSqlQueryService);
    public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _InsuranceServicesSqlQueryService);
    IMdmCopyCustomerRepository ICustomerUnitOfWork.CustomerRepository => CustomerRepository;
}
