using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.EmailAddressResponse;
using CustomerBase.API.Business.Domain.Entities;

namespace CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
public interface IEmailAddressMapper
{
    EmailAddress DtoRegisterToDomain(EmailAddressCustomerRegisterRequest dtoEmail);
    List<EmailAddress> DtoRegisterToDomain(List<EmailAddressCustomerRegisterRequest> dtoEmails);
    EmailAddressCustomerResponse DomainToCustomerDtoResponse(EmailAddress email);
    List<EmailAddressCustomerResponse> DomainToCustomerDtoResponse(List<EmailAddress> emails);
}
