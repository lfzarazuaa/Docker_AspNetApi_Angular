using Microsoft.AspNetCore.Mvc;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.MdmMaster;
using WebApiMdm.Services.MdmMaster;

namespace WebApiMdm.Controllers.MdmMaster;
[Route("api/[controller]")]
[ApiController]
public class CustomerDataOrchestrationController : ControllerBase
{
    private readonly ICustomerDataOrchestrationService _service;

    public CustomerDataOrchestrationController(ICustomerDataOrchestrationService service)
    {
        _service = service;
    }
    
    [HttpPost("copy/customers")]
    public ActionResult CopyCustomersToMdmMaster()
    {
        bool isCopied = _service.CopyCustomersToMdmMaster();
        if (isCopied)
            return Ok("Data copied successfully.");
        else
            return BadRequest("Failed to copy data.");
    }

    [HttpGet("copied/customers")]
    public ActionResult<IEnumerable<StagingCustomerDto>> GetCopiedCustomers()
    {
        var data = _service.GetCopiedCustomers();
        return Ok(data);
    }

    [HttpDelete("delete/copied/customers")]
    public ActionResult DeleteAllCopiedCustomers()
    {
        bool isDeleted = _service.DeleteAllCopiedCustomers();
        if (isDeleted)
            return Ok("Copied customers deleted successfully.");
        else
            return BadRequest("Failed to delete copied customers.");
    }

    [HttpPost("confirm/staging")]
    public ActionResult ConfirmStaging()
    {
        bool isConfirmed = _service.ConfirmStaging();
        if (isConfirmed)
            return Ok("Staging confirmed successfully.");
        else
            return BadRequest("Failed to confirm staging.");
    }

    [HttpGet("staging/customers")]
    public ActionResult<IEnumerable<StagingCustomerDto>> GetStagedCustomers()
    {
        var data = _service.GetStagedCustomers();
        return Ok(data);
    }

    [HttpDelete("delete/staging/customers")]
    public ActionResult DeleteAllStagingCustomers()
    {
        bool isDeleted = _service.DeleteAllStagingCustomers();
        if (isDeleted)
            return Ok("Staging customers deleted successfully.");
        else
            return BadRequest("Failed to delete staging customers.");
    }

    [HttpGet("staging/grouped/customers")]
    public ActionResult<IEnumerable<GroupedCustomerDto>> GetGroupedStagedCustomers()
    {
        var data = _service.GetGroupedStagedCustomers();
        return Ok(data);
    }

    [HttpPost("finalize/customers")]
    public ActionResult FinalizeCustomers([FromBody] IEnumerable<StagingCustomerGuidDto> guidsToAccept)
    {
        bool isFinalized = _service.FinalizeCustomers(guidsToAccept);
        if (isFinalized)
            return Ok("Customers finalized successfully.");
        else
            return BadRequest("Failed to finalize customers.");
    }

    [HttpGet("finalized/customers")]
    public ActionResult<IEnumerable<string>> GetFinalizedCustomers()
    {
        var data = _service.GetFinalizedCustomers();
        return Ok(data);
    }

    [HttpDelete("delete/finalized/customers")]
    public ActionResult DeleteAllFinalCustomers()
    {
        bool isDeleted = _service.DeleteAllFinalCustomers();
        if (isDeleted)
            return Ok("Finalized customers deleted successfully.");
        else
            return BadRequest("Failed to delete finalized customers.");
    }

    [HttpGet("finalized/grouped/customers")]
    public ActionResult<IEnumerable<GroupedCustomerDto>> GetGroupedFinalCustomers()
    {
        var data = _service.GetGroupedFinalCustomers();
        return Ok(data);
    }

}

