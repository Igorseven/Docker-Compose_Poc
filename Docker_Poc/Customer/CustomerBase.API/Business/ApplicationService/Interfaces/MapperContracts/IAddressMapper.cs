using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;
using CustomerBase.API.Business.Domain.Entities;

namespace CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface IAddressMapper
{
    Address DtoRegisterToDomain(AddressCustomerRegisterRequest dtoAddress);
    List<Address> DtoRegisterToDomain(List<AddressCustomerRegisterRequest> dtoAddresses);
    AddressCustomerResponse DomainToCustomerDtoResponse(Address address);
    List<AddressCustomerResponse> DomainToCustomerDtoResponse(List<Address> addresses);
}
