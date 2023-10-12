namespace WebApiMdm.Models.Dtos.Response.MdmMaster;
public class StagingCustomerDto
{
    public string Guid { get; set; } = "";
    public string OriginalDB { get; set; } = "";
    public string OriginalDBID { get; set; } = "";
    public string Username { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string? CURP { get; set; }
    public string? Passport { get; set; } 
    public string Email { get; set; } = "";
}

