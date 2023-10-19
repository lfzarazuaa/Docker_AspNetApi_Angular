using WebApiMdm.Models.Dtos.Request.MdmMaster;

namespace WebApiMdm.DataAccess.Repositories.Interfaces;
public interface IMdmCopyCustomerRepository
{
    IEnumerable<CopyCustomerDto> GetMdmCopyCustomers();
}
