using Azure.Core;
using Dapper;
using System.Data;
using System.Data.Common;
using WebApiMdm.DataAccess.Services.Interfaces;
using WebApiMdm.Models.Dtos.Request.MdmMaster;
using WebApiMdm.Models.Dtos.Response.MdmMaster;
using Z.Dapper.Plus;

namespace WebApiMdm.DataAccess.Repositories.MdmMaster.CustomerDataAccessor;
public class CustomerRepository : Repository, ICustomerRepository
{

    public CustomerRepository(IDbConnection connection, IMdmMasterSqlQueryService sqlQueryService) : base(connection, sqlQueryService, "CustomerDataAccessor", "CustomersQueries.sql")
    {
    }

    public bool CopyCustomers(params IEnumerable<CopyCustomerDto>[] copiedCustomers)
    {
        using (_connection) // Ensure that your connection is open
        {
            _connection.Open();
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string query = _queries["TruncateCopiedCustomers"];
                    _connection.Execute(query, transaction: transaction);

                    _connection.UseBulkOptions(options =>
                    {
                        options.TableHintSql = "CopiedCustomers";
                        options.DestinationTableName = "CopiedCustomers";
                        options.Transaction = (DbTransaction)transaction;
                    })
                    .BulkInsert(copiedCustomers);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }
        return true;
    }

    public IEnumerable<CopyCustomerDto> GetCopiedCustomers()
    {
        string query = _queries["GetCopiedCustomers"];
        return _connection.Query<CopyCustomerDto>(query);
    }

    public bool DeleteAllCopiedCustomers()
    {
        try
        {
            string query = _queries["TruncateCopiedCustomers"];
            _connection.Execute(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public IEnumerable<StagingCustomerDto> GetStagingCustomers()
    {
        string query = _queries["GetStagingCustomers"];
        return _connection.Query<StagingCustomerDto>(query);
    }

    public bool SaveStagingCustomers(params IEnumerable<StagingCustomerDto>[] stagingCustomers)
    {
        using (_connection) // Ensure that your connection is open
        {
            _connection.Open();
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string query = _queries["TruncateStagingCustomers"];
                    _connection.Execute(query, transaction: transaction);

                    _connection.UseBulkOptions(options =>
                    {
                        options.TableHintSql = "StagingCustomers";
                        options.DestinationTableName = "StagingCustomers";
                        options.Transaction = (DbTransaction)transaction;
                    })
                    .BulkInsert(stagingCustomers);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }
        return true;
    }

    public bool DeleteAllStagingCustomers()
    {
        try
        {
            string query = _queries["TruncateStagingCustomers"];
            _connection.Execute(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }

    public IEnumerable<GroupedCustomerDto> GetGroupedStagingCustomers()
    {
        string query = _queries["GetGroupedStagingCustomers"];
        return _connection.Query<GroupedCustomerDto>(query);
    }

    public bool SaveFinalCustomers(params IEnumerable<StagingCustomerDto>[] stagingCustomers)
    {
        using (_connection) // Ensure that your connection is open
        {
            _connection.Open();
            using (var transaction = _connection.BeginTransaction())
            {
                try
                {
                    string query = _queries["TruncateFinalCustomers"];
                    _connection.Execute(query, transaction: transaction);

                    _connection.UseBulkOptions(options =>
                    {
                        options.TableHintSql = "FinalCustomers";
                        options.DestinationTableName = "FinalCustomers";
                        options.Transaction = (DbTransaction)transaction;
                    })
                    .BulkInsert(stagingCustomers);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                    return false;
                }
            }
        }
        return true;
    }

    public IEnumerable<StagingCustomerDto> GetFinalCustomers()
    {
        string query = _queries["GetFinalCustomers"];
        return _connection.Query<StagingCustomerDto>(query);
    }

    public bool DeleteAllFinalCustomers()
    {
        try
        {
            string query = _queries["TruncateFinalCustomers"];
            _connection.Execute(query);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return false;
        }
        return true;
    }
    
    public IEnumerable<GroupedCustomerDto> GetGroupedFinalCustomers()
    {
        string query = _queries["GetGroupedFinalCustomers"];
        return _connection.Query<GroupedCustomerDto>(query);
    }

    public IEnumerable<(string Guid, string OriginalDb, int OriginalDbId)> GetGuidRowsFromCriteria(SearchCustomerDto request)
    {
        string query = _queries["GetGuidRowsFromCriteria"];
        return _connection.Query<(string, string, int)>(query, request).ToList();
    }
}

