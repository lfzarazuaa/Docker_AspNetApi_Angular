using System.Data;

namespace WebApiMdm.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IDbConnection Connection { get; }
        public void Dispose();
    }
}
