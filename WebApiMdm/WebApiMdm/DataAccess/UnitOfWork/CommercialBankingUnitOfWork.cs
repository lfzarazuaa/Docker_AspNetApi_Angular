using WebApiMdm.DataAccess.Connection.CommercialBanking;
using WebApiMdm.DataAccess.Repositories.CommercialBanking.CustomerDataAccessor;
using WebApiMdm.DataAccess.Repositories.CommercialBanking.UtilsDataAccessor;
using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.DataAccess.UnitOfWork.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class CommercialBankingUnitOfWork : UnitOfWork, ICustomerUnitOfWork
{
    private readonly ICommercialBankingSqlQueryService _commercialbankingSqlQueryService;
    
    public CommercialBankingUnitOfWork(CommercialBankingDbConfig config, ICommercialBankingSqlQueryService sqlQueryService) : base(config.ConnectionString??string.Empty)

    {
        _commercialbankingSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _commercialbankingSqlQueryService);
    public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _commercialbankingSqlQueryService);
    IMdmCopyCustomerRepository ICustomerUnitOfWork.CustomerRepository => CustomerRepository;
}
