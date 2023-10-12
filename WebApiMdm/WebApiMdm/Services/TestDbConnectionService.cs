using WebApiMdm.DataAccess.UnitOfWork;
using WebApiMdm.Models.Dtos.Response.Utils;

namespace WebApiMdm.Services;
public class TestDbConnectionService : ITestDbConnectionService
{
    private readonly AdventureWorks2019UnitOfWork _adventureWorks2019unitOfWork;
    private readonly AssetsManagementUnitOfWork _assetsManagementUnitOfWork;
    private readonly CommercialBankingUnitOfWork _commercialBankingUnitOfWork;
    private readonly InsurancesServicesUnitOfWork _insurancesServicesUnitOfWork;
    private readonly MdmMasterUnitOfWork _mdmMasterUnitOfWork;
    private readonly RetailBankingUnitOfWork _retailBankingUnitOfWork;

    public TestDbConnectionService(
        AdventureWorks2019UnitOfWork adventureWorks2019unitOfWork,
        AssetsManagementUnitOfWork assetsManagementUnitOfWork,
        CommercialBankingUnitOfWork commercialBankingUnitOfWork,
        InsurancesServicesUnitOfWork insurancesServicesUnitOfWork,
        MdmMasterUnitOfWork mdmMasterUnitOfWork,
        RetailBankingUnitOfWork retailBankingUnitOfWork
    )
    {
        _adventureWorks2019unitOfWork = adventureWorks2019unitOfWork;
        _assetsManagementUnitOfWork = assetsManagementUnitOfWork;
        _commercialBankingUnitOfWork = commercialBankingUnitOfWork;
        _insurancesServicesUnitOfWork = insurancesServicesUnitOfWork;
        _mdmMasterUnitOfWork = mdmMasterUnitOfWork;
        _retailBankingUnitOfWork = retailBankingUnitOfWork;
    }

    public string GetAdventureWorks2019DbVersion()
    {
        return _adventureWorks2019unitOfWork.UtilsRepository.GetDatabaseVersion();
    }

    public IEnumerable<DatabaseTableDetailsResponse> GetAdventureWorks2019DbTablesDetails()
    {
        return _adventureWorks2019unitOfWork.UtilsRepository.GetDatabaseTables();
    }

    public string GetAssetsManagementDbVersion()
    {
        return _assetsManagementUnitOfWork.UtilsRepository.GetDatabaseVersion();
    }

    public IEnumerable<DatabaseTableDetailsResponse> GetAssetsManagementDbTablesDetails()
    {
        return _assetsManagementUnitOfWork.UtilsRepository.GetDatabaseTables();
    }

    public string GetCommercialBankingDbVersion()
    {
        return _commercialBankingUnitOfWork.UtilsRepository.GetDatabaseVersion();
    }

    public IEnumerable<DatabaseTableDetailsResponse> GetCommercialBankingDbTablesDetails()
    {
        return _commercialBankingUnitOfWork.UtilsRepository.GetDatabaseTables();
    }

    public string GetInsurancesServicesDbVersion()
    {
        return _insurancesServicesUnitOfWork.UtilsRepository.GetDatabaseVersion();
    }

    public IEnumerable<DatabaseTableDetailsResponse> GetInsurancesServicesDbTablesDetails()
    {
        return _insurancesServicesUnitOfWork.UtilsRepository.GetDatabaseTables();
    }

    public string GetMdmMasterDbVersion()
    {
        return _mdmMasterUnitOfWork.UtilsRepository.GetDatabaseVersion();
    }

    public IEnumerable<DatabaseTableDetailsResponse> GetMdmMasterDbTablesDetails()
    {
        return _mdmMasterUnitOfWork.UtilsRepository.GetDatabaseTables();
    }

    public string GetRetailBankingDbVersion()
    {
        return _retailBankingUnitOfWork.UtilsRepository.GetDatabaseVersion();
    }

    public IEnumerable<DatabaseTableDetailsResponse> GetRetailBankingDbTablesDetails()
    {
        return _retailBankingUnitOfWork.UtilsRepository.GetDatabaseTables();
    }
}


