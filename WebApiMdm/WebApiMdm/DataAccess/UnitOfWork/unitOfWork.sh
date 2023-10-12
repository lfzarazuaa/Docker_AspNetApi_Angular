databases=("AssetsManagement" "CommercialBanking" "InsurancesServices" "MdmMaster" "RetailBanking")

for dbname in "${databases[@]}"; do
    echo "using WebApiMdm.DataAccess.Connection.${dbname};
using WebApiMdm.DataAccess.Services.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork;

public class ${dbname}UnitOfWork : UnitOfWork
{
    private readonly I${dbname}SqlQueryService _${dbname,,}SqlQueryService;
    
    public ${dbname}UnitOfWork(${dbname}DbConfig config, I${dbname}SqlQueryService sqlQueryService) : base(config.ConnectionString??\"\")

    {
        _${dbname,,}SqlQueryService = sqlQueryService;
    }

    public ICustomerRepository CustomerRepository => new CustomerRepository(Connection, _${dbname,,}SqlQueryService);
}" > ${dbname}UnitOfWork.cs
done
