using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.CustomerRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.CustomerResponse;
using CustomerBase.API.Business.Domain.Entities;

namespace CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface ICustomerMapper
{
    Customer DtoRegisterToDomain(CustomerRegisterRequest dtoCustomer);

    CustomerDataResponse DomainToDataDtoResponse(Customer customer);

    List<CustomerDataResponse> DomainToDataDtoResponse(List<Customer> customers);

    CustomerWithEmailAndMainAddressResponse DomainToEmailAndMainAddressDtoResponse(Customer customer);

}
