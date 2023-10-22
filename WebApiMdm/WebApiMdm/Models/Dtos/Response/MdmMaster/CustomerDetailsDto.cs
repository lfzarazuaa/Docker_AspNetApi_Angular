using WebApiMdm.Models.Dtos.Response.AssetsManagement;
using WebApiMdm.Models.Dtos.Response.CommercialBanking;
using WebApiMdm.Models.Dtos.Response.InsuranceServices;
using WebApiMdm.Models.Dtos.Response.RetailBanking;

namespace WebApiMdm.Models.Dtos.Response.MdmMaster;
public class CustomerDetailsDto
{
    public AssetsManagementCustomer? AssetsManagement { get; set; }
    public CommercialBankingCustomer? CommercialBanking { get; set; }
    public InsuranceServicesCustomer? InsuranceServices { get; set; }
    public RetailBankingCustomer? RetailBanking { get; set; }
}
