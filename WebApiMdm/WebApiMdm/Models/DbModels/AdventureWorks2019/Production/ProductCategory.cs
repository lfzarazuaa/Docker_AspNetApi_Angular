namespace WebApiMdm.Models.DbModels.AdventureWorks2019.Production;


public class ProductCategory
{
    public int ProductCategoryID { get; set; }
    public string? Name { get; set; }
    public int? ParentProductCategoryID { get; set; }
    public DateTime ModifiedDate { get; set; }
}


