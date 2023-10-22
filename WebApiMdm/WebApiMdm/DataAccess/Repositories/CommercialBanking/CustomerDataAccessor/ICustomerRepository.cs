using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.Models.Dtos.Response.CommercialBanking;

namespace WebApiMdm.DataAccess.Repositories.CommercialBanking.CustomerDataAccessor;
public interface ICustomerRepository: IMdmCopyCustomerRepository
{
    IEnumerable<CommercialBankingCustomer> GetCustomers();
    CommercialBankingCustomer GetCustomerData(int id);
}
