using WebApiMdm.Models.Dtos.Request.MdmMaster;

namespace WebApiMdm.Models.Dtos.Response.MdmMaster;
public class StagingCustomerDto : CopyCustomerDto
{
    public string Guid { get; set; } = "";
}

