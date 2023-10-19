using WebApiMdm.DataAccess.Repositories.Interfaces;

namespace WebApiMdm.DataAccess.UnitOfWork.Interfaces;

public interface ICustomerUnitOfWork
{
    IMdmCopyCustomerRepository CustomerRepository { get; }
}