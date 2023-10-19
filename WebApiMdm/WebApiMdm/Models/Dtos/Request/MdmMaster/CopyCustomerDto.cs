namespace WebApiMdm.Models.Dtos.Request.MdmMaster;
public class CopyCustomerDto
{
    public string OriginalDb { get; set; } = "";
    public string OriginalDbId { get; set; } = "";
    public string Username { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string? CURP { get; set; }
    public string? Passport { get; set; }
    public string Email { get; set; } = "";
}
