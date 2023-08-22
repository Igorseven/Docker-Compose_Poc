using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.TelephoneResponse;
using CustomerBase.API.Business.ApplicationService.Interfaces.MapperContracts;
using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Extensions;

namespace CustomerBase.API.Business.ApplicationService.Mappers;
public sealed class TelephoneMapper : ITelephoneMapper
{
    public Telephone DtoRegisterToDomain(TelephoneCustomerRegisterRequest dtoTelephone) =>
        new()
        {
            Ddi = dtoTelephone.Ddi.RemoveCaracters(),
            PhoneNumber = dtoTelephone.PhoneNumber.RemoveCaracters(),
            Ddd = dtoTelephone.Ddd?.RemoveCaracters(),
            TelephoneType = dtoTelephone.TelephoneType
        };

    public List<Telephone> DtoRegisterToDomain(List<TelephoneCustomerRegisterRequest> dtoTelephones)
    {
        List<Telephone> telephones = new();

        foreach (var dtoTelephone in dtoTelephones)
        {
            var telephone = DtoRegisterToDomain(dtoTelephone);

            telephones.Add(telephone);
        }

        return telephones;
    }

    public TelephoneCustomerResponse DomainToCustomerDtoResponse(Telephone telephone) =>
        new()
        {
            TelephoneId = telephone.TelephoneId,
            TelephoneType = telephone.TelephoneType,
            Ddi = telephone.Ddi,
            Ddd = telephone.Ddd,
            PhoneNumber = telephone.PhoneNumber
        };

    public List<TelephoneCustomerResponse> DomainToCustomerDtoResponse(List<Telephone> telephones)
    {
        List<TelephoneCustomerResponse> dtoPhones = new();

        foreach (var telephone in telephones)
        {
            var phone = DomainToCustomerDtoResponse(telephone);

            dtoPhones.Add(phone);
        }

        return dtoPhones;
    }
}
