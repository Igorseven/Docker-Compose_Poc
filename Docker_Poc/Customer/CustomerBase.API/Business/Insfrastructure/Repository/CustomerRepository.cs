using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Handlers.PaginationHandler;
using CustomerBase.API.Business.Domain.Handlers.PaginationHandler.PageParamsWithFilters;
using CustomerBase.API.Business.Domain.Interfaces.OthersContracts;
using CustomerBase.API.Business.Domain.Interfaces.RepositoryContracts;
using CustomerBase.API.Business.Insfrastructure.ORM.Context;
using CustomerBase.API.Business.Insfrastructure.Repository.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace CustomerBase.API.Business.Insfrastructure.Repository;
public sealed class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
{
    private readonly IPaginationQueryService<Customer> _paginationQueryService;

    public CustomerRepository(ApplicationContext context,
                              IPaginationQueryService<Customer> paginationQueryService)
        : base(context)
    {
        _paginationQueryService = paginationQueryService;
    }

    public async Task<bool> HaveInDatabaseAsync(Expression<Func<Customer, bool>> where) => await _dbSet.AnyAsync(where);

    public async Task<PageList<Customer>> FindAllWithpaginationAsync(PageParamsCustomeFilter pageParams,
                                                                     Expression<Func<Customer, Customer>>? selector = null)
    {
        IQueryable<Customer> query = _dbSet;

        if (selector is not null)
            query = query.Select(selector);

        query = query.OrderByDescending(c => c.CustomerId);

        return await _paginationQueryService.CreatePaginationAsync(query, pageParams.PageSize, pageParams.PageNumber);
    }

    public async Task<List<Customer>> FindAllAsync(Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null)
    {
        IQueryable<Customer> query = _dbSet;

        if (include is not null)
            query = include(query);

        return await query.AsNoTracking().ToListAsync();
    }

    public async Task<Customer?> FindByPredicateAsync(Expression<Func<Customer, bool>> predicate,
                                                      Func<IQueryable<Customer>, IIncludableQueryable<Customer, object>>? include = null,
                                                      bool asNoTracking = false)
    {
        IQueryable<Customer> query = _dbSet;

        if (asNoTracking)
            query = query.AsNoTracking();

        if (include is not null)
            query = include(query);

        return await query.FirstOrDefaultAsync(predicate);
    }


    public async Task<bool> SaveAsync(Customer customer)
    {
        await _dbSet.AddAsync(customer);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        _dbSet.Update(customer);

        return await SaveInDatabaseAsync();
    }

    public async Task<bool> DeleteAsync(int customerId) =>
        await _dbSet.Where(c => c.CustomerId == customerId).ExecuteDeleteAsync() > 0;

}
