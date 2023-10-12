using WebApiMdm.DataAccess.Connection.RetailBanking;
using WebApiMdm.DataAccess.Repositories.RetailBanking.UtilsDataAccessor;
using WebApiMdm.DataAccess.Services.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class RetailBankingUnitOfWork : UnitOfWork
{
    private readonly IRetailBankingSqlQueryService _retailbankingSqlQueryService;
    
    public RetailBankingUnitOfWork(RetailBankingDbConfig config, IRetailBankingSqlQueryService sqlQueryService) : base(config.ConnectionString??"")

    {
        _retailbankingSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _retailbankingSqlQueryService);
    //public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _retailbankingSqlQueryService);
}
