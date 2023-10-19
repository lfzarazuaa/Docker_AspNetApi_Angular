using WebApiMdm.DataAccess.Repositories.Interfaces;

namespace WebApiMdm.DataAccess.Repositories.RetailBanking.CustomerDataAccessor;
public interface ICustomerRepository: IMdmCopyCustomerRepository
{
    IEnumerable<dynamic> GetCustomers();
}
