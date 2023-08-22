using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Handlers.PaginationHandler;
using CustomerBase.API.Business.Domain.Handlers.PaginationHandler.PageParamsWithFilters;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CustomerBase.API.Business.Domain.Interfaces.RepositoryContracts;
public interface ICustomerRepository : IDisposable
{

    Task<bool> SaveAsync(Customer customer);
    Task<bool> UpdateAsync(Customer customer);
    Task<bool> DeleteAsync(int customerId);
    Task<bool> HaveInDatabaseAsync(Expression<Func<Customer, bool>> where);

    Task<Customer?> FindByPredicateAsync(Expression<Func<Customer, bool>> predicate,
                                         Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null,
                                         bool asNoTracking = false);
    Task<PageList<Customer>> FindAllWithpaginationAsync(PageParamsCustomeFilter pageParams,
                                                        Expression<Func<Customer, Customer>>? selector = null);

    Task<List<Customer>> FindAllAsync(Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null);
}
