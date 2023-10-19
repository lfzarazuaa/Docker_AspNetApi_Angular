using Dapper;
using System.Data;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.Dtos.Request.MdmMaster;

namespace WebApiMdm.DataAccess.Repositories.RetailBanking.CustomerDataAccessor;

public class CustomerRepository : Repository, ICustomerRepository
{
    public CustomerRepository(IDbConnection connection, IRetailBankingSqlQueryService sqlQueryService) : base(connection, sqlQueryService, "CustomerDataAccessor", "CustomersQueries.sql")
    {
    }

    public IEnumerable<dynamic> GetCustomers()
    {
        string query = _queries["GetCustomers"];
        return _connection.Query(query);
    }

    public IEnumerable<CopyCustomerDto> GetMdmCopyCustomers()
    {
        string query = _queries["GetMdmCopyCustomers"];
        return _connection.Query<CopyCustomerDto>(query);
    }
}
