namespace WebApiMdm.Models.Dtos.Response.InsuranceServices;
public class InsuranceServicesCustomer
{
    public int CustomerId { get; set; }
    public string Username { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Email { get; set; } = "";
    public DateTime Birthdate { get; set; }
    public string? CURP { get; set; }
    public string? Passport { get; set; }
    public string Phone { get; set; } = "";
    public string Address { get; set; } = "";   
}
