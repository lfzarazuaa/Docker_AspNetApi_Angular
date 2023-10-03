namespace WebApiMdm.Models.DbModels.AdventureWorks2019.Production;

public class Location
{
    public short LocationID { get; set; }
    public string? Name { get; set; }
    public decimal CostRate { get; set; }
    public decimal Availability { get; set; }
    public DateTime ModifiedDate { get; set; }
}

