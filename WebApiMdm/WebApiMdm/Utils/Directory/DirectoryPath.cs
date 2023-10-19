using System.Runtime.InteropServices;
namespace WebApiMdm.Utils.Directory;

public static class DirectoryPath
{
    public static readonly string SolutionDirectory = 
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
            ? AppContext.BaseDirectory.Split(new[] { @"bin\" }, StringSplitOptions.None)[0]
            : Path.Combine(AppContext.BaseDirectory, "..", "..", "..");
    public static readonly string AdventureWorks2019DataAccessDirectory = Path.Combine(SolutionDirectory, "DataAccess", "Repositories", "AdventureWorks2019");
    public static readonly string AdventureWorks2019ProductionDirectory = Path.Combine(AdventureWorks2019DataAccessDirectory, "Production");
    public static readonly string AssetsManagementDataAccessDirectory = Path.Combine(SolutionDirectory, "DataAccess", "Repositories", "AssetsManagement");
    public static readonly string CommercialBankingDataAccessDirectory = Path.Combine(SolutionDirectory, "DataAccess", "Repositories", "CommercialBanking");
    public static readonly string InsuranceServicesDataAccessDirectory = Path.Combine(SolutionDirectory, "DataAccess", "Repositories", "InsuranceServices");
    public static readonly string MdmMasterDataAccessDirectory = Path.Combine(SolutionDirectory, "DataAccess", "Repositories", "MdmMaster");
    public static readonly string RetailBankingDataAccessDirectory = Path.Combine(SolutionDirectory, "DataAccess", "Repositories", "RetailBanking");

}

