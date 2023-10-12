using WebApiMdm.DataAccess.Connection.CommercialBanking;
using WebApiMdm.DataAccess.Repositories.CommercialBanking.UtilsDataAccessor;
using WebApiMdm.DataAccess.Services.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class CommercialBankingUnitOfWork : UnitOfWork
{
    private readonly ICommercialBankingSqlQueryService _commercialbankingSqlQueryService;
    
    public CommercialBankingUnitOfWork(CommercialBankingDbConfig config, ICommercialBankingSqlQueryService sqlQueryService) : base(config.ConnectionString??"")

    {
        _commercialbankingSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _commercialbankingSqlQueryService);
    //public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _commercialbankingSqlQueryService);
}
