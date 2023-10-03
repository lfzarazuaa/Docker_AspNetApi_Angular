using System.Runtime.InteropServices;
namespace WebApiMdm.Utils.Directory;

public static class DirectoryPath
{
    public static readonly string SolutionDirectory = 
            RuntimeInformation.IsOSPlatform(OSPlatform.Windows) 
            ? AppContext.BaseDirectory.Split(new[] { @"bin\" }, StringSplitOptions.None)[0]
            : Path.Combine(AppContext.BaseDirectory, "..", "..", "..");
    public static readonly string AdventureWorks2019DataAccessDirectory = Path.Combine(SolutionDirectory, "DataAccess", "Repositories", "AdventureWorks2019", "Production");
    public static readonly string AdventureWorks2019ProductionDirectory = Path.Combine(AdventureWorks2019DataAccessDirectory, "Production");
}

