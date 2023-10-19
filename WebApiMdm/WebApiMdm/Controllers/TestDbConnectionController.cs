using Microsoft.AspNetCore.Mvc;
using WebApiMdm.Models.Dtos.Response.Utils;
using WebApiMdm.Services;

namespace WebApiMdm.Controllers;
[Route("api/[controller]")]
[ApiController]
public class TestDbConnectionController : ControllerBase
{
    private readonly ITestDbConnectionService _testDbConnectionService;

    public TestDbConnectionController(ITestDbConnectionService testDbConnectionService)
    {
        _testDbConnectionService = testDbConnectionService;
    }

    // GET: api/TestDbConnection/AdventureWorks2019/DbVersion
    [HttpGet(@"AdventureWorks2019/DbVersion")]
    public ActionResult<string> GetAdventureWorks2019DbVersion()
    {
        return Ok(_testDbConnectionService.GetAdventureWorks2019DbVersion());
    }

    // GET: api/TestDbConnection/AdventureWorks2019/DbTablesDetails
    [HttpGet(@"AdventureWorks2019/DbTablesDetails")]
    public ActionResult<IEnumerable<DatabaseTableDetailsResponse>> GetAdventureWorks2019DbTablesDetails()
    {
        return Ok(_testDbConnectionService.GetAdventureWorks2019DbTablesDetails());
    }

    // GET: api/TestDbConnection/AssetsManagement/DbVersion
    [HttpGet(@"AssetsManagement/DbVersion")]
    public ActionResult<string> GetAssetsManagementDbVersion()
    {
        return Ok(_testDbConnectionService.GetAssetsManagementDbVersion());
    }

    // GET: api/TestDbConnection/AssetsManagement/DbTablesDetails
    [HttpGet(@"AssetsManagement/DbTablesDetails")]
    public ActionResult<IEnumerable<DatabaseTableDetailsResponse>> GetAssetsManagementDbTablesDetails()
    {
        return Ok(_testDbConnectionService.GetAssetsManagementDbTablesDetails());
    }

    // GET: api/TestDbConnection/CommercialBanking/DbVersion
    [HttpGet(@"CommercialBanking/DbVersion")]
    public ActionResult<string> GetCommercialBankingDbVersion()
    {
        return Ok(_testDbConnectionService.GetCommercialBankingDbVersion());
    }

    // GET: api/TestDbConnection/CommercialBanking/DbTablesDetails
    [HttpGet(@"CommercialBanking/DbTablesDetails")]
    public ActionResult<IEnumerable<DatabaseTableDetailsResponse>> GetCommercialBankingDbTablesDetails()
    {
        return Ok(_testDbConnectionService.GetCommercialBankingDbTablesDetails());
    }

    // GET: api/TestDbConnection/InsuranceServices/DbVersion
    [HttpGet(@"InsuranceServices/DbVersion")]
    public ActionResult<string> GetInsuranceServicesDbVersion()
    {
        return Ok(_testDbConnectionService.GetInsuranceServicesDbVersion());
    }

    // GET: api/TestDbConnection/InsuranceServices/DbTablesDetails
    [HttpGet(@"InsuranceServices/DbTablesDetails")]
    public ActionResult<IEnumerable<DatabaseTableDetailsResponse>> GetInsuranceServicesDbTablesDetails()
    {
        return Ok(_testDbConnectionService.GetInsuranceServicesDbTablesDetails());
    }

    // GET: api/TestDbConnection/MdmMaster/DbVersion
    [HttpGet(@"MdmMaster/DbVersion")]
    public ActionResult<string> GetMdmMasterDbVersion()
    {
        return Ok(_testDbConnectionService.GetMdmMasterDbVersion());
    }

    // GET: api/TestDbConnection/MdmMaster/DbTablesDetails
    [HttpGet(@"MdmMaster/DbTablesDetails")]
    public ActionResult<IEnumerable<DatabaseTableDetailsResponse>> GetMdmMasterDbTablesDetails()
    {
        return Ok(_testDbConnectionService.GetMdmMasterDbTablesDetails());
    }

    // GET: api/TestDbConnection/RetailBanking/DbVersion
    [HttpGet(@"RetailBanking/DbVersion")]
    public ActionResult<string> GetRetailBankingDbVersion()
    {
        return Ok(_testDbConnectionService.GetRetailBankingDbVersion());
    }

    // GET: api/TestDbConnection/RetailBanking/DbTablesDetails
    [HttpGet(@"RetailBanking/DbTablesDetails")]
    public ActionResult<IEnumerable<DatabaseTableDetailsResponse>> GetRetailBankingDbTablesDetails()
    {
        return Ok(_testDbConnectionService.GetRetailBankingDbTablesDetails());
    }


}
