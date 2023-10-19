using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.MdmMaster;

namespace WebApiMdm.Utils.Extensions;
public static class ConvertExtensions
{
    public static StagingCustomerDto ToStagingCustomerDto(this CopyCustomerDto value)
    {
        string guid = (value is StagingCustomerDto) ? ((StagingCustomerDto)value).Guid : string.Empty; 
        return new StagingCustomerDto
        {
            Guid = guid,
            OriginalDb = value.OriginalDb,
            OriginalDbId = value.OriginalDbId,
            Username = value.Username,
            FirstName = value.FirstName,
            LastName = value.LastName,
            Email = value.Email,
            CURP = value.CURP,
            Passport = value.Passport
        };
    }

    public static List<StagingCustomerDto> ToStagingCustomerDto(this IEnumerable<CopyCustomerDto> value)
    {
        return value.Aggregate(new List<StagingCustomerDto>(), (a, b) =>
        {
            a.Add(b.ToStagingCustomerDto());
            return a;
        });
    }
}

