using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.Models.Dtos.Response.AssetsManagement;

namespace WebApiMdm.DataAccess.Repositories.AssetsManagement.CustomerDataAccessor;
public interface ICustomerRepository: IMdmCopyCustomerRepository
{
    IEnumerable<AssetsManagementCustomer> GetCustomers();
    AssetsManagementCustomer GetCustomerData(int id);
}