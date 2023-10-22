using Dapper;
using System.Data;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.RetailBanking;

namespace WebApiMdm.DataAccess.Repositories.RetailBanking.CustomerDataAccessor;

public class CustomerRepository : Repository, ICustomerRepository
{
    public CustomerRepository(IDbConnection connection, IRetailBankingSqlQueryService sqlQueryService) : base(connection, sqlQueryService, "CustomerDataAccessor", "CustomersQueries.sql")
    {
    }

    public IEnumerable<RetailBankingCustomer> GetCustomers()
    {
        string query = _queries["GetCustomers"];
        return _connection.Query<RetailBankingCustomer>(query);
    }

    public RetailBankingCustomer GetCustomerData(int id)
    {
        string query = _queries["GetCustomerData"];
        return _connection.QueryFirst<RetailBankingCustomer>(query, new { Id = id });
    }

    public IEnumerable<CopyCustomerDto> GetMdmCopyCustomers()
    {
        string query = _queries["GetMdmCopyCustomers"];
        return _connection.Query<CopyCustomerDto>(query);
    }
}
