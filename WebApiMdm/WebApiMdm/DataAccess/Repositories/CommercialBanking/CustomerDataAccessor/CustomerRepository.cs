using Dapper;
using System.Data;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.CommercialBanking;

namespace WebApiMdm.DataAccess.Repositories.CommercialBanking.CustomerDataAccessor;

public class CustomerRepository : Repository, ICustomerRepository
{
    public CustomerRepository(IDbConnection connection, ICommercialBankingSqlQueryService sqlQueryService) : base(connection, sqlQueryService, "CustomerDataAccessor", "CustomersQueries.sql")
    {
    }

    public IEnumerable<CommercialBankingCustomer> GetCustomers()
    {
        string query = _queries["GetCustomers"];
        return _connection.Query<CommercialBankingCustomer>(query);
    }

    public CommercialBankingCustomer GetCustomerData(int id)
    {
        string query = _queries["GetCustomerData"];
        return _connection.QueryFirst<CommercialBankingCustomer>(query, new { Id = id });
    }

    public IEnumerable<CopyCustomerDto> GetMdmCopyCustomers()
    {
        string query = _queries["GetMdmCopyCustomers"];
        return _connection.Query<CopyCustomerDto>(query);
    }
}
