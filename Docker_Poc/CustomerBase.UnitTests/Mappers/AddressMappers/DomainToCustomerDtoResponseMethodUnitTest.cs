using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Mappers.AddressMappers.Base;

namespace CustomerBase.UnitTests.Mappers.AddressMappers;
public sealed class DomainToCustomerDtoResponseMethodUnitTest : AddressMapperSetup
{
    [Fact]
    [Trait("Mapping", "Domain to customer response")]
    public void DomainToCustomerDtoResponse_ResponseAddressCustomerResponse()
    {
        var address = new Address
        {
            AddressId = 1,
            AddressType = EAddressType.MainProperty,
            Localization = "Localization",
            District = "District",
            City = "City",
            Country = "Country",
            State = "state",
            ZipCode = "8000-9000",
            Number = "15A",
            Complement = null,
            CustomerId = 1
        };

        var mappingResult = _addressMapper.DomainToCustomerDtoResponse(address);

        Assert.NotNull(mappingResult);
        Assert.Equal(address.AddressId, mappingResult.AddressId);
        Assert.Equal(address.AddressType, mappingResult.AddressType);
        Assert.Equal(address.Localization, mappingResult.Localization);
        Assert.Equal(address.District, mappingResult.District);
        Assert.Equal(address.City, mappingResult.City);
        Assert.Equal(address.Country, mappingResult.Country);
        Assert.Equal(address.State, mappingResult.State);
        Assert.Equal("80009000", mappingResult.ZipCode);
        Assert.Equal(address.Number, mappingResult.Number);
        Assert.Null(mappingResult.Complement);
    }


    [Fact]
    [Trait("Mapping", "Domain to customer list response")]
    public void DomainToCustomerDtoResponse_ResponseAddressCustomerResponseList()
    {
        var addresses = new List<Address>()
        {
            new Address
            {
                AddressId = 1,
                AddressType = EAddressType.MainProperty,
                Localization = "Localization",
                District = "District",
                City = "City",
                Country = "Country",
                State = "state",
                ZipCode = "80009000",
                Number = "15A",
                Complement = null,
                CustomerId = 1
            }
        };

        var mappingResult = _addressMapper.DomainToCustomerDtoResponse(addresses);

        Assert.NotEmpty(mappingResult);
        Assert.True(mappingResult.Count == 1);
    }
}
