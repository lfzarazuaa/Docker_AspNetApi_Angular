using Dapper;
using System.Data;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.Dtos.Request.MdmMaster;

namespace WebApiMdm.DataAccess.Repositories.AssetsManagement.CustomerDataAccessor;

public class CustomerRepository : Repository, ICustomerRepository
{
    public CustomerRepository(IDbConnection connection, IAssetsManagementSqlQueryService sqlQueryService) : base(connection, sqlQueryService, "CustomerDataAccessor", "CustomerQueries.sql")
    {
    }

    public IEnumerable<dynamic> GetCustomers()
    {
        string query = _queries["GetCustomerData"];
        return _connection.Query(query);
    }

    public IEnumerable<CopyCustomerDto> GetMdmCopyCustomers()
    {
        string query = _queries["GetMdmCopyCustomers"];
        return _connection.Query<CopyCustomerDto>(query);
    }
}