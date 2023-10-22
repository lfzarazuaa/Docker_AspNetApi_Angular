using System.Linq;
using WebApiMdm.DataAccess.Repositories.Interfaces;
using WebApiMdm.DataAccess.Repositories.RetailBanking.CustomerDataAccessor;
using WebApiMdm.DataAccess.UnitOfWork;
using WebApiMdm.DataAccess.UnitOfWork.Interfaces;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.MdmMaster;
using WebApiMdm.Utils.Extensions;
using WebApiMdm.Utils.Helpers;

namespace WebApiMdm.Services.MdmMaster;
public class CustomerDataOrchestrationService : ICustomerDataOrchestrationService
{

    private readonly AssetsManagementUnitOfWork _assetsManagementUnitOfWork;
    private readonly CommercialBankingUnitOfWork _commercialBankingUnitOfWork;
    private readonly InsuranceServicesUnitOfWork _insuranceServicesUnitOfWork;
    private readonly MdmMasterUnitOfWork _mdmMasterUnitOfWork;
    private readonly RetailBankingUnitOfWork _retailBankingUnitOfWork;


    public CustomerDataOrchestrationService(
        AssetsManagementUnitOfWork assetsManagementUnitOfWork,
        CommercialBankingUnitOfWork commercialBankingUnitOfWork,
        InsuranceServicesUnitOfWork InsuranceServicesUnitOfWork,
        MdmMasterUnitOfWork mdmMasterUnitOfWork,
        RetailBankingUnitOfWork retailBankingUnitOfWork
    )
    {
        _assetsManagementUnitOfWork = assetsManagementUnitOfWork;
        _commercialBankingUnitOfWork = commercialBankingUnitOfWork;
        _insuranceServicesUnitOfWork = InsuranceServicesUnitOfWork;
        _mdmMasterUnitOfWork = mdmMasterUnitOfWork;
        _retailBankingUnitOfWork = retailBankingUnitOfWork;
    }

    public bool CopyCustomersToMdmMaster()
    {
        // Logic to copy data from other DBs to MdmMasterDb
        List<ICustomerUnitOfWork> mdmCopyCustomerRepositories = new List<ICustomerUnitOfWork>()
        {
            _assetsManagementUnitOfWork,
            _commercialBankingUnitOfWork,
            _insuranceServicesUnitOfWork,
            _retailBankingUnitOfWork
        };


        IEnumerable<CopyCustomerDto>[] copyCustomers = mdmCopyCustomerRepositories.Select(copyCustomerRepository => copyCustomerRepository.CustomerRepository.GetMdmCopyCustomers()).ToArray();

        return _mdmMasterUnitOfWork.CustomerRepository.CopyCustomers(copyCustomers);
    }

    public IEnumerable<CopyCustomerDto> GetCopiedCustomers()
    {
        return _mdmMasterUnitOfWork.CustomerRepository.GetCopiedCustomers();
    }

    public bool DeleteAllCopiedCustomers()
    {
        return _mdmMasterUnitOfWork.CustomerRepository.DeleteAllCopiedCustomers();
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
            var stagingCustomers = allCustomers.OrderBy(c => c.Guid).ToList();

            return _mdmMasterUnitOfWork.CustomerRepository.SaveStagingCustomers(stagingCustomers);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return false;
        }

    }

    public IEnumerable<StagingCustomerDto> GetStagedCustomers()
    {
        return _mdmMasterUnitOfWork.CustomerRepository.GetStagingCustomers();
    }

    public bool DeleteAllStagingCustomers()
    {
        return _mdmMasterUnitOfWork.CustomerRepository.DeleteAllStagingCustomers();
    }

    public IEnumerable<GroupedCustomerDto> GetGroupedStagedCustomers()
    {
        return _mdmMasterUnitOfWork.CustomerRepository.GetGroupedStagingCustomers();
    }

    public bool FinalizeCustomers(IEnumerable<StagingCustomerGuidDto> guidsToAccept)
    {
        try
        {
            var existingStagedCustomers = GetStagedCustomers().ToList();

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

            var finalizedCustomers = existingStagedCustomers;
            _mdmMasterUnitOfWork.CustomerRepository.SaveFinalCustomers(finalizedCustomers);
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
        return _mdmMasterUnitOfWork.CustomerRepository.GetFinalCustomers();
    }

    public bool DeleteAllFinalCustomers()
    {
        return _mdmMasterUnitOfWork.CustomerRepository.DeleteAllFinalCustomers();
    }
    
    public IEnumerable<GroupedCustomerDto> GetGroupedFinalCustomers()
    {
        return _mdmMasterUnitOfWork.CustomerRepository.GetGroupedFinalCustomers();
    }

    public HttpResult<CustomerDetailsDto> GetCustomerDetails(SearchCustomerDto request)
    {
        var builder = new HttpResult<CustomerDetailsDto>.Builder();
        try
        {
            if (request == null)
            {
                return builder.Failure("Invalid params", StatusCodes.Status400BadRequest).Build();
            }

            var tuples = _mdmMasterUnitOfWork.CustomerRepository.GetGuidRowsFromCriteria(request);

            if (tuples == null || !tuples.Any())
                return builder.Failure("No data found for the given criteria", 404).Build();

            var customerDetails = new CustomerDetailsDto();
            foreach (var tuple in tuples)
            {
                switch (tuple.OriginalDb)
                {
                    case "AssetsManagement":
                        customerDetails.AssetsManagement =
                            _assetsManagementUnitOfWork.CustomerRepository.GetCustomerData(tuple.OriginalDbId);
                        break;
                    case "CommercialBanking":
                        customerDetails.CommercialBanking =
                            _commercialBankingUnitOfWork.CustomerRepository.GetCustomerData(tuple.OriginalDbId);
                        break;
                    case "InsuranceServices":
                        customerDetails.InsuranceServices =
                            _insuranceServicesUnitOfWork.CustomerRepository.GetCustomerData(tuple.OriginalDbId);
                        break;
                    case "RetailBanking":
                        customerDetails.RetailBanking =
                            _retailBankingUnitOfWork.CustomerRepository.GetCustomerData(tuple.OriginalDbId);
                        break;
                    default:
                        break;
                }
            }
            return builder.Success(customerDetails).Build();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return builder.Failure("Internal Server Error", 505).Build();
        }
    }
}

