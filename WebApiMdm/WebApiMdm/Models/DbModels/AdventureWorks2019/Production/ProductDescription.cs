namespace WebApiMdm.Models.DbModels.AdventureWorks2019.Production;

public class ProductDescription
{
    public int ProductDescriptionID { get; set; }
    public string? Description { get; set; }
    public Guid Rowguid { get; set; }
    public DateTime ModifiedDate { get; set; }
}

