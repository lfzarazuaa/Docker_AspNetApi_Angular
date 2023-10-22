using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.Models.Dtos.Response.RetailBanking;

namespace WebApiMdm.DataAccess.Repositories.RetailBanking.CustomerDataAccessor;
public interface ICustomerRepository: IMdmCopyCustomerRepository
{
    IEnumerable<RetailBankingCustomer> GetCustomers();
    RetailBankingCustomer GetCustomerData(int id);
}
