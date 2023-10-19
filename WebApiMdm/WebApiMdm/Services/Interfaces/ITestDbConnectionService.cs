using WebApiMdm.Models.Dtos.Response.Utils;

namespace WebApiMdm.Services;
public interface ITestDbConnectionService
{
    IEnumerable<DatabaseTableDetailsResponse> GetAdventureWorks2019DbTablesDetails();
    string GetAdventureWorks2019DbVersion();

    IEnumerable<DatabaseTableDetailsResponse> GetAssetsManagementDbTablesDetails();
    string GetAssetsManagementDbVersion();

    IEnumerable<DatabaseTableDetailsResponse> GetCommercialBankingDbTablesDetails();
    string GetCommercialBankingDbVersion();

    IEnumerable<DatabaseTableDetailsResponse> GetInsuranceServicesDbTablesDetails();
    string GetInsuranceServicesDbVersion();

    IEnumerable<DatabaseTableDetailsResponse> GetMdmMasterDbTablesDetails();
    string GetMdmMasterDbVersion();

    IEnumerable<DatabaseTableDetailsResponse> GetRetailBankingDbTablesDetails();
    string GetRetailBankingDbVersion();
}
