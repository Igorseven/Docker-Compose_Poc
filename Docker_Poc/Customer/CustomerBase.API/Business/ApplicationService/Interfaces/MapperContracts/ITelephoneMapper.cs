using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.TelephoneResponse;
using CustomerBase.API.Business.Domain.Entities;

namespace CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface ITelephoneMapper
{
    Telephone DtoRegisterToDomain(TelephoneCustomerRegisterRequest dtoTelephone);
    List<Telephone> DtoRegisterToDomain(List<TelephoneCustomerRegisterRequest> dtoTelephones);
    TelephoneCustomerResponse DomainToCustomerDtoResponse(Telephone telephone);
    List<TelephoneCustomerResponse> DomainToCustomerDtoResponse(List<Telephone> telephones);
}
