using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.MdmMaster;

namespace WebApiMdm.Services.MdmMaster;
public interface ICustomerDataOrchestrationService
{
    bool CopyCustomersToMdmMaster();
    bool ConfirmStaging();
    bool FinalizeCustomers(IEnumerable<StagingCustomerGuidDto> guidsToAccept);
    IEnumerable<CopyCustomerDto> GetCopiedCustomers();
    IEnumerable<StagingCustomerDto> GetFinalizedCustomers();
    IEnumerable<StagingCustomerDto> GetStagedCustomers();
    IEnumerable<GroupedCustomerDto> GetGroupedStagedCustomers();
    IEnumerable<GroupedCustomerDto> GetGroupedFinalCustomers();
    public bool DeleteAllCopiedCustomers();
    public bool DeleteAllStagingCustomers();
    public bool DeleteAllFinalCustomers();
}