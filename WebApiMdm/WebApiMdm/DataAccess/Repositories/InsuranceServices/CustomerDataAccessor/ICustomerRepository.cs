using WebApiMdm.DataAccess.Repositories.Interfaces;

namespace WebApiMdm.DataAccess.Repositories.InsuranceServices.CustomerDataAccessor;
public interface ICustomerRepository: IMdmCopyCustomerRepository
{
    IEnumerable<dynamic> GetCustomers();
}
