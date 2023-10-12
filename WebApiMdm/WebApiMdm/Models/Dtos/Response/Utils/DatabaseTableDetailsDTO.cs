namespace WebApiMdm.Models.Dtos.Response.Utils;
public class DatabaseTableDetailsResponse
{
    public string DatabaseName { get; set; } = "";
    public string TableName { get; set; } = ""; 
    public string FieldName { get; set; } = "";
    public string DataType { get; set; } = "";  
    public int? MaxLength { get; set; }  // Nullable int to accommodate fields without a specified max length
}