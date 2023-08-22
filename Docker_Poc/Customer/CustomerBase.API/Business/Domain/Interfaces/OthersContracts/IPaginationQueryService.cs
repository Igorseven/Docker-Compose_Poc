using CustomerBase.API.Business.Domain.Handlers.PaginationHandler;

namespace CustomerBase.API.Business.Domain.Interfaces.OthersContracts;
public interface IPaginationQueryService<T> where T : class
{
    Task<PageList<T>> CreatePaginationAsync(IQueryable<T> source, int pageSize, int pageNumber);
}
