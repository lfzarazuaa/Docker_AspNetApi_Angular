using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.MdmMaster;

namespace WebApiMdm.DataAccess.Repositories.MdmMaster.CustomerDataAccessor;
public interface ICustomerRepository
{
    bool CopyCustomers(params IEnumerable<CopyCustomerDto>[] copiedCustomers);
    bool DeleteAllCopiedCustomers();
    bool DeleteAllFinalCustomers();
    bool DeleteAllStagingCustomers();
    IEnumerable<CopyCustomerDto> GetCopiedCustomers();
    IEnumerable<StagingCustomerDto> GetFinalCustomers();
    IEnumerable<StagingCustomerDto> GetStagingCustomers();
    IEnumerable<GroupedCustomerDto> GetGroupedFinalCustomers();
    IEnumerable<GroupedCustomerDto> GetGroupedStagingCustomers();
    bool SaveStagingCustomers(params IEnumerable<StagingCustomerDto>[] stagingCustomers);
    bool SaveFinalCustomers(params IEnumerable<StagingCustomerDto>[] stagingCustomers);
}