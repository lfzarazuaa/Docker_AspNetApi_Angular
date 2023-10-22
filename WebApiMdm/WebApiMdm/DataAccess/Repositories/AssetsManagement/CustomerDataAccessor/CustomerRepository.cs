using Dapper;
using System.Data;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.AssetsManagement;

namespace WebApiMdm.DataAccess.Repositories.AssetsManagement.CustomerDataAccessor;

public class CustomerRepository : Repository, ICustomerRepository
{
    public CustomerRepository(IDbConnection connection, IAssetsManagementSqlQueryService sqlQueryService) : base(connection, sqlQueryService, "CustomerDataAccessor", "CustomerQueries.sql")
    {
    }

    public IEnumerable<AssetsManagementCustomer> GetCustomers()
    {
        string query = _queries["GetCustomers"];
        return _connection.Query<AssetsManagementCustomer>(query);
    }

    public AssetsManagementCustomer GetCustomerData(int id)
    {
        string query = _queries["GetCustomerData"];
        return _connection.QueryFirst<AssetsManagementCustomer>(query, new { Id = id });
    }

    public IEnumerable<CopyCustomerDto> GetMdmCopyCustomers()
    {
        string query = _queries["GetMdmCopyCustomers"];
        return _connection.Query<CopyCustomerDto>(query);
    }
}