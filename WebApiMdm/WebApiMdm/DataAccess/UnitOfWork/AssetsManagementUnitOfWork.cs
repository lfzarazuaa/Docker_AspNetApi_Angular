using WebApiMdm.DataAccess.Connection.AssetsManagement;
using WebApiMdm.DataAccess.Repositories.AssetsManagement.CustomerDataAccessor;
using WebApiMdm.DataAccess.Repositories.AssetsManagement.UtilsDataAccessor;
using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.DataAccess.UnitOfWork.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class AssetsManagementUnitOfWork : UnitOfWork, ICustomerUnitOfWork
{
    private readonly IAssetsManagementSqlQueryService _assetsmanagementSqlQueryService;

    public AssetsManagementUnitOfWork(AssetsManagementDbConfig config, IAssetsManagementSqlQueryService sqlQueryService) : base(config.ConnectionString ?? string.Empty)

    {
        _assetsmanagementSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _assetsmanagementSqlQueryService);
    
    public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _assetsmanagementSqlQueryService);

    IMdmCopyCustomerRepository ICustomerUnitOfWork.CustomerRepository => CustomerRepository;
}

