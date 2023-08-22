using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;

namespace CustomerBase.API.Business.ApplicationService.Interfaces.ServiceContracts;
public interface ICustomerCommandService : IDisposable
{
    Task<bool> CustomerRegisterAsync(CustomerRegisterRequest dtoCustomer);
}
