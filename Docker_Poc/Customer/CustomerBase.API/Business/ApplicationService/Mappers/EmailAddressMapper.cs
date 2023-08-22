using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.EmailAddressRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.EmailAddressResponse;
using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.Domain.Entities;

namespace CustomerBase.API.Business.ApplicationService.Mappers;
public sealed class EmailAddressMapper : IEmailAddressMapper
{
    public EmailAddress DtoRegisterToDomain(EmailAddressCustomerRegisterRequest dtoEmail) =>
        new()
        {
            EmailType = dtoEmail.EmailType,
            Email = dtoEmail.Email,
        };

    public List<EmailAddress> DtoRegisterToDomain(List<EmailAddressCustomerRegisterRequest> dtoEmails)
    {
        List<EmailAddress> emails = new();

        foreach (var dtoEmail in dtoEmails)
        {
            var email = DtoRegisterToDomain(dtoEmail);

            emails.Add(email);
        }

        return emails;
    }

    public EmailAddressCustomerResponse DomainToCustomerDtoResponse(EmailAddress email) =>
        new()
        {
            EmailAddressId = email.EmailAddressId,
            EmailType = email.EmailType,
            Email = email.Email
        };

    public List<EmailAddressCustomerResponse> DomainToCustomerDtoResponse(List<EmailAddress> emails)
    {
        List<EmailAddressCustomerResponse> dtoEmails = new();

        foreach (var email in emails)
        {
            var dtoEmail = DomainToCustomerDtoResponse(email);

            dtoEmails.Add(dtoEmail);
        }

        return dtoEmails;
    }
}
