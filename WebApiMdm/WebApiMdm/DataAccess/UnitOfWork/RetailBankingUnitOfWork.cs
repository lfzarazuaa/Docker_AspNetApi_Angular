using WebApiMdm.DataAccess.Connection.RetailBanking;
using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.DataAccess.Repositories.RetailBanking.CustomerDataAccessor;
using WebApiMdm.DataAccess.Repositories.RetailBanking.UtilsDataAccessor;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.DataAccess.UnitOfWork.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class RetailBankingUnitOfWork : UnitOfWork, ICustomerUnitOfWork
{
    private readonly IRetailBankingSqlQueryService _retailbankingSqlQueryService;
    
    public RetailBankingUnitOfWork(RetailBankingDbConfig config, IRetailBankingSqlQueryService sqlQueryService) : base(config.ConnectionString??string.Empty)

    {
        _retailbankingSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _retailbankingSqlQueryService);
    public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _retailbankingSqlQueryService);
    IMdmCopyCustomerRepository ICustomerUnitOfWork.CustomerRepository => CustomerRepository;
}
