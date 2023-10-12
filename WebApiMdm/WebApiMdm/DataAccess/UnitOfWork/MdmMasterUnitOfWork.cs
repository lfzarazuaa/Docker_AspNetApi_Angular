using WebApiMdm.DataAccess.Connection.MdmMaster;
using WebApiMdm.DataAccess.Repositories.MdmMaster.UtilsDataAccessor;
using WebApiMdm.DataAccess.Services.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class MdmMasterUnitOfWork : UnitOfWork
{
    private readonly IMdmMasterSqlQueryService _mdmmasterSqlQueryService;
    
    public MdmMasterUnitOfWork(MdmMasterDbConfig config, IMdmMasterSqlQueryService sqlQueryService) : base(config.ConnectionString??"")

    {
        _mdmmasterSqlQueryService = sqlQueryService;
    }

    public IUtilsRepository UtilsRepository => new UtilsRepository(Connection, _mdmmasterSqlQueryService);
    //public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _mdmmasterSqlQueryService);
}
