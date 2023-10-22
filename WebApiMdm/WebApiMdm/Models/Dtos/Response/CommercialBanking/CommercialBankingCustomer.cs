namespace WebApiMdm.Models.Dtos.Response.CommercialBanking;
public class CommercialBankingCustomer
{
    public int CustomerId { get; set; }
    public string Username { get; set; } = "";
    public string Email { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public DateTime Birthdate { get; set; }
    public int CustomerBranch { get; set; }
    public string? CURP { get; set; }
    public string? Passport { get; set; }
    public string Address { get; set; } = "";
    public string CustomerCity { get; set; } = "";
}
