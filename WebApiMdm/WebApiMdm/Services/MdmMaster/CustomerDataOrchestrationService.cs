using WebApiMdm.DataAccess.UnitOfWork;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.MdmMaster;

namespace WebApiMdm.Services.MdmMaster;
public class CustomerDataOrchestrationService : ICustomerDataOrchestrationService
{
    private static List<StagingCustomerDto> _finalizedCustomers = new List<StagingCustomerDto>();
    private static List<StagingCustomerDto> _stagingCustomers = new List<StagingCustomerDto>();

    private readonly AssetsManagementUnitOfWork _assetsManagementUnitOfWork;
    private readonly CommercialBankingUnitOfWork _commercialBankingUnitOfWork;
    private readonly InsurancesServicesUnitOfWork _insurancesServicesUnitOfWork;
    private readonly MdmMasterUnitOfWork _mdmMasterUnitOfWork;
    private readonly RetailBankingUnitOfWork _retailBankingUnitOfWork;


    public CustomerDataOrchestrationService(
        AssetsManagementUnitOfWork assetsManagementUnitOfWork,
        CommercialBankingUnitOfWork commercialBankingUnitOfWork,
        InsurancesServicesUnitOfWork insurancesServicesUnitOfWork,
        MdmMasterUnitOfWork mdmMasterUnitOfWork,
        RetailBankingUnitOfWork retailBankingUnitOfWork
    )
    {
        _assetsManagementUnitOfWork = assetsManagementUnitOfWork;
        _commercialBankingUnitOfWork = commercialBankingUnitOfWork;
        _insurancesServicesUnitOfWork = insurancesServicesUnitOfWork;
        _mdmMasterUnitOfWork = mdmMasterUnitOfWork;
        _retailBankingUnitOfWork = retailBankingUnitOfWork;
    }

    public bool CopyCustomersToMdmMaster()
    {
        // Logic to copy data from other DBs to MdmMasterDb
        // For now, I'm adding a simple log for demonstration.
        Console.WriteLine("Copying data from other databases to MdmMasterDb...");
        // Actual logic should go here.
        return true;
    }

    public IEnumerable<StagingCustomerDto> GetCopiedCustomers()
    {
        return GetFakeCopiedCustomers();
    }

    public bool ConfirmStaging()
    {
        try
        {
            var allCustomers = GetCopiedCustomers().ToList();
            var guidMap = new Dictionary<string, string>();  // To store assigned GUIDs to avoid re-generating for same CURP/Passport.

            foreach (var customer in allCustomers)
            {
                if (string.IsNullOrEmpty(customer.CURP) && string.IsNullOrEmpty(customer.Passport))
                {
                    throw new InvalidOperationException("Both CURP and Passport cannot be null for a customer.");
                }

                var key = customer.CURP ?? customer.Passport ?? "";

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
            _stagingCustomers = GetFakeStagedCustomersB().ToList();
            return false;
        }
        
    }

    public IEnumerable<StagingCustomerDto> GetStagedCustomers()
    {
        return GetFakeStagedCustomers();
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

    private static IEnumerable<StagingCustomerDto> GetFakeCopiedCustomers()
    {
        // Fake/static data for demonstration purposes
        return new List<StagingCustomerDto>
        {
            new StagingCustomerDto
            {
                OriginalDB = "AssetsManagement",
                OriginalDBID = "1",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new StagingCustomerDto
            {
                OriginalDB = "CommercialBanking",
                OriginalDBID = "125",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new StagingCustomerDto
            {
                OriginalDB = "InsurancesServices",
                OriginalDBID = "137",
                Username = "jdoe",
                FirstName = "John",
                LastName = "Doe",
                Email = "john.doe@email.com",
                CURP = null,
                Passport = "P123456"
            },
            new StagingCustomerDto
            {
                OriginalDB = "CommercialBanking",
                OriginalDBID = "2",
                Username = "mperez",
                FirstName = "Maria",
                LastName = "Perez Ramos",
                Email = "maria.p@email.com",
                CURP = null,
                Passport = "CA003547943"
            },
            new StagingCustomerDto
            {
                OriginalDB = "InsurancesServices",
                OriginalDBID = "2",
                Username = "mperez",
                FirstName = "Maria",
                LastName = "Perez Ramos",
                Email = "maria.p@email.com",
                CURP = null,
                Passport = "CA003547943"
            },
            new StagingCustomerDto
            {
                OriginalDB = "InsurancesServices",
                OriginalDBID = "3",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new StagingCustomerDto
            {
                OriginalDB = "AssetsManagement",
                OriginalDBID = "12",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new StagingCustomerDto
            {
                OriginalDB = "InsurancesServices",
                OriginalDBID = "5",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new StagingCustomerDto
            {
                OriginalDB = "RetailBanking",
                OriginalDBID = "117",
                Username = "rjuare",
                FirstName = "Roberto",
                LastName = "Juarez Gomez",
                Email = "roberto.j@email.com",
                CURP = "JUGR800610HMNRBO04",
                Passport = "MX003547944"
            },
            new StagingCustomerDto
            {
                OriginalDB = "InsurancesServices",
                OriginalDBID = "412",
                Username = "gvasqu",
                FirstName = "Gabriela",
                LastName = "Vasquez Hernandez",
                Email = "gabriela.v@email.com",
                CURP = "VASH901025MDFTSN05",
                Passport = null
            },
            new StagingCustomerDto
            {
                OriginalDB = "RetailBanking",
                OriginalDBID = "467",
                Username = "gvasqu",
                FirstName = "Gabriela",
                LastName = "Vasquez Hernandez",
                Email = "gabriela.v@email.com",
                CURP = "VASH901025MDFTSN05",
                Passport = null
            },
            new StagingCustomerDto
            {
                OriginalDB = "AssetsManagement",
                OriginalDBID = "53",
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
                OriginalDB = "AssetsManagement",
                OriginalDBID = "1",
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
                OriginalDB = "CommercialBanking",
                OriginalDBID = "125",
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
                OriginalDB = "InsurancesServices",
                OriginalDBID = "137",
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
                OriginalDB = "CommercialBanking",
                OriginalDBID = "2",
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
                OriginalDB = "InsurancesServices",
                OriginalDBID = "2",
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
                OriginalDB = "InsurancesServices",
                OriginalDBID = "3",
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
                OriginalDB = "AssetsManagement",
                OriginalDBID = "12",
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
                OriginalDB = "InsurancesServices",
                OriginalDBID = "5",
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
                OriginalDB = "RetailBanking",
                OriginalDBID = "117",
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
                OriginalDB = "InsurancesServices",
                OriginalDBID = "412",
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
                OriginalDB = "RetailBanking",
                OriginalDBID = "467",
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
                OriginalDB = "AssetsManagement",
                OriginalDBID = "53",
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
}

