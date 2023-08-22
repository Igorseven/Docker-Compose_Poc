using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;

namespace CustomerBase.API.Business.ApplicationService.Interfaces.ServiceContracts;
public interface ICustomerQueryService
{
    Task<CustomerWithEmailAndMainAddressResponse?> FindByCustomerIdAsync(int customerId);

    Task<IEnumerable<CustomerDataResponse>> FindAllCustomerWithEmailAndMainTelephoneAsync();
}
