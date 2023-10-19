using WebApiMdm.DataAccess.Repositories.Interfaces;

namespace WebApiMdm.DataAccess.Repositories.AssetsManagement.CustomerDataAccessor;
public interface ICustomerRepository: IMdmCopyCustomerRepository
{
    IEnumerable<dynamic> GetCustomers();
}