using WebApiMdm.DataAccess.UnitOfWork;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.MdmMaster;
using WebApiMdm.Utils.Extensions;
using WebApiMdm.Utils.Helpers;

namespace WebApiMdm.Services.MdmMaster;

public class CustomerDataOrchestrationServiceFake : ICustomerDataOrchestrationService
{
    private static List<CopyCustomerDto> _copiedCustomers = new List<CopyCustomerDto>();
    private static List<StagingCustomerDto> _stagingCustomers = new List<StagingCustomerDto>();
    private static List<StagingCustomerDto> _finalizedCustomers = new List<StagingCustomerDto>();

    private readonly AssetsManagementUnitOfWork _assetsManagementUnitOfWork;
    private readonly CommercialBankingUnitOfWork _commercialBankingUnitOfWork;
    private readonly InsuranceServicesUnitOfWork _InsuranceServicesUnitOfWork;
    private readonly MdmMasterUnitOfWork _mdmMasterUnitOfWork;
    private readonly RetailBankingUnitOfWork _retailBankingUnitOfWork;


    public CustomerDataOrchestrationServiceFake(
        AssetsManagementUnitOfWork assetsManagementUnitOfWork,
        CommercialBankingUnitOfWork commercialBankingUnitOfWork,
        InsuranceServicesUnitOfWork InsuranceServicesUnitOfWork,
        MdmMasterUnitOfWork mdmMasterUnitOfWork,
        RetailBankingUnitOfWork retailBankingUnitOfWork
    )
    {
        _assetsManagementUnitOfWork = assetsManagementUnitOfWork;
        _commercialBankingUnitOfWork = commercialBankingUnitOfWork;
        _InsuranceServicesUnitOfWork = InsuranceServicesUnitOfWork;
        _mdmMasterUnitOfWork = mdmMasterUnitOfWork;
        _retailBankingUnitOfWork = retailBankingUnitOfWork;
    }

    public bool CopyCustomersToMdmMaster()
    {
        // Logic to copy data from other DBs to MdmMasterDb
        // For now, I'm adding a simple log for demonstration.
        Console.WriteLine("Copying data from other databases to MdmMasterDb...");
        // Actual logic should go here.
        _copiedCustomers = GetFakeCopiedCustomers().ToList();
        return true;
    }

    public IEnumerable<CopyCustomerDto> GetCopiedCustomers()
    {
        return _copiedCustomers;
    }

    public bool DeleteAllCopiedCustomers()
    {
        _copiedCustomers.Clear();
        return true;
    }

    public bool ConfirmStaging()
    {
        try
        {
            List<StagingCustomerDto> allCustomers = GetCopiedCustomers().ToStagingCustomerDto();
            var guidMap = new Dictionary<string, string>();  // To store assigned GUIDs to avoid re-generating for same CURP/Passport.

            foreach (var customer in allCustomers)
            {
                if (string.IsNullOrEmpty(customer.CURP) && string.IsNullOrEmpty(customer.Passport))
                {
                    throw new InvalidOperationException("Both CURP and Passport cannot be null for a customer.");
                }

                var key = customer.CURP ?? customer.Passport ?? string.Empty;

                if (!guidMap.ContainsKey(key))
                {
                    guidMap[key] = Guid.NewGuid().ToString().ToUpper();
                }

                customer.Guid = guidMap[key];
            }
            _stagingCustomers = allCustomers;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }

    }

    public IEnumerable<StagingCustomerDto> GetStagedCustomers()
    {
        return GetFakeStagedCustomers();
    }

    public bool DeleteAllStagingCustomers()
    {
        _stagingCustomers.Clear();
        return true;
    }

    public bool FinalizeCustomers(IEnumerable<StagingCustomerGuidDto> guidsToAccept)
    {
        try
        {
            var existingStagedCustomers = GetFakeStagedCustomers().ToList();

            foreach (var customer in existingStagedCustomers)
            {
                if (!guidsToAccept.Any(g => g.Guid == customer.Guid))
                {
                    customer.Guid = Guid.NewGuid().ToString().ToUpper();
                }
                else
                {
                    customer.Guid = customer.Guid;
                }
            }

            _finalizedCustomers = existingStagedCustomers;
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }

    }

    public IEnumerable<StagingCustomerDto> GetFinalizedCustomers()
    {
        return GetFakeFinalizedCustomers();
    }

    private static IEnumerable<CopyCustomerDto> GetFakeCopiedCustomers()
    {
        // Fake/static data for demonstration purposes
        return new List<CopyCustomerDto>
        {
            new CopyCustomerDto
            {
                OriginalDb = "AssetsManagement",
                OriginalDbId = "1",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new CopyCustomerDto
            {
                OriginalDb = "CommercialBanking",
                OriginalDbId  = "125",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new CopyCustomerDto
            {
                OriginalDb = "InsuranceServices",
                OriginalDbId = "137",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new CopyCustomerDto
            {
                OriginalDb = "CommercialBanking",
                OriginalDbId = "2",
                Username = "mperez",
                FirstName = "Maria",
                LastName = "Perez Ramos",
                Email = "maria.p@email.com",
                CURP = null,
                Passport = "CA003547943"
            },
            new CopyCustomerDto
            {
                OriginalDb = "InsuranceServices",
                OriginalDbId = "2",
                Username = "mperez",
                FirstName = "Maria",
                LastName = "Perez Ramos",
                Email = "maria.p@email.com",
                CURP = null,
                Passport = "CA003547943"
            },
            new CopyCustomerDto
            {
                OriginalDb = "InsuranceServices",
                OriginalDbId = "3",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new CopyCustomerDto
            {
                OriginalDb = "AssetsManagement",
                OriginalDbId = "12",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new CopyCustomerDto
            {
                OriginalDb = "CommercialBanking",
                OriginalDbId = "5",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new CopyCustomerDto
            {
                OriginalDb = "RetailBanking",
                OriginalDbId = "117",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new CopyCustomerDto
            {
                OriginalDb = "InsuranceServices",
                OriginalDbId = "412",
                Username = "gvasqu",
                FirstName = "Gabriela",
                LastName = "Vasquez Hernandez",
                Email = "gabriela.v@email.com",
                CURP = "VASH901025MDFTSN05",
                Passport = null
            },
            new CopyCustomerDto
            {
                OriginalDb = "RetailBanking",
                OriginalDbId = "467",
                Username = "gvasqu",
                FirstName = "Gabriela",
                LastName = "Vasquez Hernandez",
                Email = "gabriela.v@email.com",
                CURP = "VASH901025MDFTSN05",
                Passport = null
            },
            new CopyCustomerDto
            {
                OriginalDb = "AssetsManagement",
                OriginalDbId = "53",
                Username = "amendo",
                FirstName = "Alberto",
                LastName = "Mendoza Lira",
                Email = "alberto.m@email.com",
                CURP = null,
                Passport = "EU003547946"
            }
            // Add more fake customers as needed
        };
    }

    private static IEnumerable<StagingCustomerDto> GetFakeStagedCustomers()
    {
        // Fake/static data for demonstration purposes
        return _stagingCustomers;
    }

    private static IEnumerable<StagingCustomerDto> GetFakeStagedCustomersB()
    {
        // Fake/static data for demonstration purposes
        return new List<StagingCustomerDto>
        {
            new StagingCustomerDto
            {
                Guid = "BF9BC5EC-7A5E-4A0C-8221-ABB18F0B1293",
                OriginalDb = "AssetsManagement",
                OriginalDbId = "1",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new StagingCustomerDto
            {
                Guid = "BF9BC5EC-7A5E-4A0C-8221-ABB18F0B1293",
                OriginalDb = "CommercialBanking",
                OriginalDbId = "125",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new StagingCustomerDto
            {
                Guid = "BF9BC5EC-7A5E-4A0C-8221-ABB18F0B1293",
                OriginalDb = "InsuranceServices",
                OriginalDbId = "137",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new StagingCustomerDto
            {
                Guid = "03704662-2FF5-424D-80B4-9472213D621B",
                OriginalDb = "CommercialBanking",
                OriginalDbId = "2",
                Username = "mperez",
                FirstName = "Maria",
                LastName = "Perez Ramos",
                Email = "maria.p@email.com",
                CURP = null,
                Passport = "CA003547943"
            },
            new StagingCustomerDto
            {
                Guid = "03704662-2FF5-424D-80B4-9472213D621B",
                OriginalDb = "InsuranceServices",
                OriginalDbId = "2",
                Username = "mperez",
                FirstName = "Maria",
                LastName = "Perez Ramos",
                Email = "maria.p@email.com",
                CURP = null,
                Passport = "CA003547943"
            },
            new StagingCustomerDto
            {
                Guid = "DD6289A9-22FE-48BE-AEE8-7C2371F71FA3",
                OriginalDb = "InsuranceServices",
                OriginalDbId = "3",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new StagingCustomerDto
            {
                Guid = "DD6289A9-22FE-48BE-AEE8-7C2371F71FA3",
                OriginalDb = "AssetsManagement",
                OriginalDbId = "12",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new StagingCustomerDto
            {
                Guid = "DD6289A9-22FE-48BE-AEE8-7C2371F71FA3",
                OriginalDb = "CommercialBanking",
                OriginalDbId = "5",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new StagingCustomerDto
            {
                Guid = "DD6289A9-22FE-48BE-AEE8-7C2371F71FA3",
                OriginalDb = "RetailBanking",
                OriginalDbId = "117",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new StagingCustomerDto
            {
                Guid = "E0D95561-2019-4EA0-8464-F319B9312956",
                OriginalDb = "InsuranceServices",
                OriginalDbId = "412",
                Username = "gvasqu",
                FirstName = "Gabriela",
                LastName = "Vasquez Hernandez",
                Email = "gabriela.v@email.com",
                CURP = "VASH901025MDFTSN05",
                Passport = null
            },
            new StagingCustomerDto
            {
                Guid = "E0D95561-2019-4EA0-8464-F319B9312956",
                OriginalDb = "RetailBanking",
                OriginalDbId = "467",
                Username = "gvasqu",
                FirstName = "Gabriela",
                LastName = "Vasquez Hernandez",
                Email = "gabriela.v@email.com",
                CURP = "VASH901025MDFTSN05",
                Passport = null
            },
            new StagingCustomerDto
            {
                Guid = "C0FDD54C-170B-480A-9671-DD24DDA6DA5E",
                OriginalDb = "AssetsManagement",
                OriginalDbId = "53",
                Username = "amendo",
                FirstName = "Alberto",
                LastName = "Mendoza Lira",
                Email = "alberto.m@email.com",
                CURP = null,
                Passport = "EU003547946"
            }
            // Add more fake customers as needed
        };
    }

    private static IEnumerable<StagingCustomerDto> GetFakeFinalizedCustomers()
    {
        // Fake/static data for demonstration purposes
        return _finalizedCustomers;
    }

    public bool DeleteAllFinalCustomers()
    {
        _finalizedCustomers.Clear();
        return true;
    }

    public IEnumerable<GroupedCustomerDto> GetGroupedStagedCustomers()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<GroupedCustomerDto> GetGroupedFinalCustomers()
    {
        throw new NotImplementedException();
    }

    public HttpResult<CustomerDetailsDto> GetCustomerDetails(SearchCustomerDto request)
    {
        throw new NotImplementedException();
    }
}

