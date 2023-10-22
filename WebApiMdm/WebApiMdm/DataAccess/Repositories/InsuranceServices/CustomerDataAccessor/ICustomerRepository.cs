using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.Models.Dtos.Response.InsuranceServices;

namespace WebApiMdm.DataAccess.Repositories.InsuranceServices.CustomerDataAccessor;
public interface ICustomerRepository: IMdmCopyCustomerRepository
{
    IEnumerable<InsuranceServicesCustomer> GetCustomers();
    InsuranceServicesCustomer GetCustomerData(int id);
}
