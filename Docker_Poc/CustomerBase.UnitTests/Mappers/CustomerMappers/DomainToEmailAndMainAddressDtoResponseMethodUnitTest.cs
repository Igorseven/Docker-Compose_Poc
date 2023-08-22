using CustomerBase.API.Business.ApplicationService.DataTransferObjects.Responses.AddressResponse;
using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.UnitTests.Builders;
using CustomerBase.UnitTests.Mappers.CustomerMappers.Base;
using Moq;

namespace CustomerBase.UnitTests.Mappers.CustomerMappers;
public sealed class DomainToEmailAndMainAddressDtoResponseMethodUnitTest : CustomerMapperSetup
{
    [Fact]
    [Trait("Mapping", "Domain to email and main address response")]
    public void DomainToEmailAndMainAddressDtoResponse_ReturnCustomerWithEmailAndMainAddressResponse()
    {
        var address = AddressBuilderTest.NewObject()
                                        .WithAddressType(EAddressType.MainProperty)
                                        .DomainObject();

        var email = EmailAddressBuilderTest.NewObject()
                                           .WithEmailType(EEmailType.Main)
                                           .WithEmail("email@test.com")
                                           .DomainObject();

        var customer = CustomerBuilderTest.NewObject()
                                          .WithFullName("Client test")
                                          .WithEmails(email)
                                          .WithAddresses(address)
                                          .DomainObject();

        var dtoAddress = new AddressCustomerResponse
        {
            AddressId = 1,
            AddressType = EAddressType.MainProperty,
            Localization = "Rua Test",
            District = "Bairro Test",
            City = "Cidade Test",
            State = "TS",
            Number = "777",
            ZipCode = "70006000",
            Complement = null,
            Country = "País Test",

        };

        _addressMapper.Setup(m => m.DomainToCustomerDtoResponse(It.IsAny<Address>())).Returns(dtoAddress);

        var mappingResult = _customerMapper.DomainToEmailAndMainAddressDtoResponse(customer);

        Assert.NotNull(mappingResult);
        Assert.Equal(customer.CustomerId, mappingResult.CustomerId);
        Assert.Equal(customer.FullName, mappingResult.FullName);
        Assert.Equal(email.Email, mappingResult.Email);
        Assert.Equal(address.AddressId, mappingResult.Address.AddressId);
        Assert.Equal(address.AddressType, mappingResult.Address.AddressType);
        Assert.Equal(address.Localization, mappingResult.Address.Localization);
        Assert.Equal(address.District, mappingResult.Address.District);
        Assert.Equal(address.City, mappingResult.Address.City);
        Assert.Equal(address.Country, mappingResult.Address.Country);
        Assert.Equal(address.State, mappingResult.Address.State);
        Assert.Equal(address.ZipCode, mappingResult.Address.ZipCode);
        Assert.Equal(address.Number, mappingResult.Address.Number);
        Assert.Null(mappingResult.Address.Complement);
        _addressMapper.Verify(m => m.DomainToCustomerDtoResponse(It.IsAny<Address>()), Times.Once());
    }
}
