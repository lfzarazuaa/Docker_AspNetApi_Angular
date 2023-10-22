namespace WebApiMdm.Models.Dtos.Response.AssetsManagement;
public class AssetsManagementCustomer
{
    public int CustomerId { get; set; }
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime Birthdate { get; set; }
    public string? CURP { get; set; }
    public string? Passport { get; set; }
}
