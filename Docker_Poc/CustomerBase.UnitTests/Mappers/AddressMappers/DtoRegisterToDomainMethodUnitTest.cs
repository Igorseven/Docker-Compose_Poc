using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Requests.AddressRequest;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Mappers.AddressMappers.Base;

namespace CustomerBase.UnitTests.Mappers.AddressMappers;
public sealed class DtoRegisterToDomainMethodUnitTest : AddressMapperSetup
{
    [Fact]
    [Trait("Mapping", "Dto register to domain")]
    public void DtoRegisterToDomain_ReturnAddress()
    {
        var dtoAddress = new AddressCustomerRegisterRequest
        {
            AddressType = EAddressType.MainProperty,
            Localization = "Localization",
            District = "District",
            City = "City",
            Number = "12B",
            State = "SP",
            Country = "Country",
            ZipCode = "80009000",
            Complement = null
        };

        var mappingResult = _addressMapper.DtoRegisterToDomain(dtoAddress);

        Assert.NotNull(mappingResult);
        Assert.Equal(dtoAddress.AddressType, mappingResult.AddressType);
        Assert.Equal(dtoAddress.Localization, mappingResult.Localization);
        Assert.Equal(dtoAddress.District, mappingResult.District);
        Assert.Equal(dtoAddress.City, mappingResult.City);
        Assert.Equal(dtoAddress.Number, mappingResult.Number);
        Assert.Equal(dtoAddress.State, mappingResult.State);
        Assert.Equal(dtoAddress.Country, mappingResult.Country);
        Assert.Equal(dtoAddress.ZipCode, mappingResult.ZipCode);
        Assert.Null(mappingResult.Complement);
    }

    [Fact]
    [Trait("Mapping", "Dto register to domain object list")]
    public void DtoRegisterToDomain_ReturnAddressList()
    {
        var dtoAddresses = new List<AddressCustomerRegisterRequest>() 
        {
            new AddressCustomerRegisterRequest
            {
                AddressType = EAddressType.MainProperty,
                Localization = "Localization",
                District = "District",
                City = "City",
                Number = "12B",
                State = "SP",
                Country = "Country",
                ZipCode = "80009000",
                Complement = null
            }
        };

        var mappingResult = _addressMapper.DtoRegisterToDomain(dtoAddresses);

        Assert.NotEmpty(mappingResult);
        Assert.True(mappingResult.Count == 1);
    }
}
