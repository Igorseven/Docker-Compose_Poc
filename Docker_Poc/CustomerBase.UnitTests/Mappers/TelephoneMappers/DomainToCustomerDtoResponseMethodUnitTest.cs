using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Mappers.TelephoneMappers.Base;

namespace CustomerBase.UnitTests.Mappers.TelephoneMappers;
public sealed class DomainToCustomerDtoResponseMethodUnitTest : TelephoneMapperSetup
{
    [Fact]
    [Trait("Mapping", "Domain to customer response")]
    public void DomainToCustomerDtoResponse_ResponseTelephoneCustomerResponse()
    {
        var telephone = new Telephone
        {
            TelephoneId = 1,
            TelephoneType = ETelephoneType.CellPhone,
            Ddi = "351",
            Ddd = null,
            PhoneNumber = "180706655",
            CustomerId = 1
        };

        var mappingResult = _telephoneMapper.DomainToCustomerDtoResponse(telephone);

        Assert.NotNull(mappingResult);
        Assert.Equal(telephone.TelephoneId, mappingResult.TelephoneId);
        Assert.Equal(telephone.TelephoneType, mappingResult.TelephoneType);
        Assert.Equal(telephone.Ddi, mappingResult.Ddi);
        Assert.Equal(telephone.Ddd, mappingResult.Ddd);
        Assert.Equal(telephone.PhoneNumber, mappingResult.PhoneNumber);
    }


    [Fact]
    [Trait("Mapping", "Domain to customer list response")]
    public void DomainToCustomerDtoResponse_ResponseTelephoneCustomerResponseList()
    {
        var telephones = new List<Telephone>()
        {
            new Telephone
            {
                TelephoneId = 1,
                TelephoneType = ETelephoneType.CellPhone,
                Ddi = "351",
                Ddd = null,
                PhoneNumber = "180706655",
                CustomerId = 1
            }
        };

        var mappingResult = _telephoneMapper.DomainToCustomerDtoResponse(telephones);

        Assert.NotNull(mappingResult);
        Assert.True(mappingResult.Count == telephones.Count);
    }
}
