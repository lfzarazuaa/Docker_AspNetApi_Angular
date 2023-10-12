using WebApiMdm.DataAccess.Connection.AssetsManagement;
using WebApiMdm.DataAccess.Repositories.AssetsManagement.UtilsDataAccessor;
using WebApiMdm.DataAccess.Services.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class AssetsManagementUnitOfWork : UnitOfWork
{
    private readonly IAssetsManagementSqlQueryService _assetsmanagementSqlQueryService;
    
    public AssetsManagementUnitOfWork(AssetsManagementDbConfig config, IAssetsManagementSqlQueryService sqlQueryService) : base(config.ConnectionString??"")

    {
        _assetsmanagementSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _assetsmanagementSqlQueryService);
    //public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _assetsmanagementSqlQueryService);
}
