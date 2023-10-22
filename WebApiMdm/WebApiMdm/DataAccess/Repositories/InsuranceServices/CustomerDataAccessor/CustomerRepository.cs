using Dapper;
using System.Data;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.InsuranceServices;

namespace WebApiMdm.DataAccess.Repositories.InsuranceServices.CustomerDataAccessor;

public class CustomerRepository : Repository, ICustomerRepository
{
    public CustomerRepository(IDbConnection connection, IInsuranceServicesSqlQueryService sqlQueryService) : base(connection, sqlQueryService, "CustomerDataAccessor", "CustomersQueries.sql")
    {
    }

    public IEnumerable<InsuranceServicesCustomer> GetCustomers()
    {
        string query = _queries["GetCustomers"];
        return _connection.Query<InsuranceServicesCustomer>(query);
    }

    public InsuranceServicesCustomer GetCustomerData(int id)
    {
        string query = _queries["GetCustomerData"];
        return _connection.QueryFirst<InsuranceServicesCustomer>(query, new { Id = id });
    }

    public IEnumerable<CopyCustomerDto> GetMdmCopyCustomers()
    {
        string query = _queries["GetMdmCopyCustomers"];
        return _connection.Query<CopyCustomerDto>(query);
    }
}
