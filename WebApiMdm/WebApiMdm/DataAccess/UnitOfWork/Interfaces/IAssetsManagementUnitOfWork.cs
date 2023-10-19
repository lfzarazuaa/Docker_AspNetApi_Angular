using WebApiMdm.DataAccess.Repositories.AssetsManagement.CustomerDataAccessor;
using WebApiMdm.DataAccess.Repositories.AssetsManagement.UtilsDataAccessor;
using WebApiMdm.DataAccess.UnitOfWork.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork.Interfaces;
public interface IAssetsManagementUnitOfWork : ICustomerUnitOfWork
{
    new ICustomerRepository CustomerRepository { get; }
    IUtilsRepository UtilsRepository { get; }
}