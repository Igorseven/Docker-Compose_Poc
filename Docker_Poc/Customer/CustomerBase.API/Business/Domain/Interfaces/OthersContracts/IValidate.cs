using CustomerBase.API.Business.Domain.Handlers.ValidationHandler;

namespace CustomerBase.API.Business.Domain.Interfaces.OthersContracts;
public interface IValidate<T> where T : class
{
    Task<ValidationResponse> ValidationAsync(T entity);
    ValidationResponse Validation(T entity);
}
