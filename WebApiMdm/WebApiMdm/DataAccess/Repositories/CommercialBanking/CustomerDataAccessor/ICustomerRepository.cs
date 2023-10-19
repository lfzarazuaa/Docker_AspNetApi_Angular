using WebApiMdm.DataAccess.Repositories.Interfaces;

namespace WebApiMdm.DataAccess.Repositories.CommercialBanking.CustomerDataAccessor;
public interface ICustomerRepository: IMdmCopyCustomerRepository
{
    IEnumerable<dynamic> GetCustomers();
}
