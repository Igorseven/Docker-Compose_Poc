using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.TelephoneRequest;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Mappers.TelephoneMappers.Base;

namespace CustomerBase.UnitTests.Mappers.TelephoneMappers;
public sealed class DtoRegisterToDomainMethodUnitTest : TelephoneMapperSetup
{
    [Fact]
    [Trait("Mapping", "Dto register to domain")]
    public void DtoRegisterToDomain_ReturnTelephone()
    {
        var dtoTelephone = new TelephoneCustomerRegisterRequest
        {
            Ddi = "+55",
            Ddd = "(18)",
            PhoneNumber = "91172-4588",
            TelephoneType = ETelephoneType.CellPhone
        };

        var mappingResult = _telephoneMapper.DtoRegisterToDomain(dtoTelephone);

        Assert.NotNull(mappingResult);
        Assert.Equal("55", mappingResult.Ddi);
        Assert.Equal("18", mappingResult.Ddd);
        Assert.Equal("911724588", mappingResult.PhoneNumber);
        Assert.Equal(dtoTelephone.TelephoneType, mappingResult.TelephoneType);
    }

    [Fact]
    [Trait("Mapping", "Dto register to domain object list")]
    public void DtoRegisterToDomain_ReturnTelephoneList()
    {
        var dtoTelephones = new List<TelephoneCustomerRegisterRequest>()
        {
            new TelephoneCustomerRegisterRequest
            {
                Ddi = "+55",
                Ddd = "(18)",
                PhoneNumber = "91172-4588",
                TelephoneType = ETelephoneType.CellPhone
            },
            new TelephoneCustomerRegisterRequest
            {
                Ddi = "+55",
                Ddd = "(18)",
                PhoneNumber = "3371-1566",
                TelephoneType = ETelephoneType.Landline
            }
        };

        var mappingResult = _telephoneMapper.DtoRegisterToDomain(dtoTelephones);

        Assert.NotEmpty(mappingResult);
        Assert.True(mappingResult.Count == 2);
    }
}
