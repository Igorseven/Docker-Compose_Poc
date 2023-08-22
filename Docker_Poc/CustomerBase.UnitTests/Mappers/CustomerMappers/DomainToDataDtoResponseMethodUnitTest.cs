using CustomerBase.API.Business.Domain.Enums;
using CustomerBase.API.Business.Domain.Entities;
using CustomerBase.UnitTests.Builders;
using CustomerBase.UnitTests.Mappers.CustomerMappers.Base;

namespace CustomerBase.UnitTests.Mappers.CustomerMappers;
public sealed class DomainToDataDtoResponseMethodUnitTest : CustomerMapperSetup
{
    [Fact]
    [Trait("Mapping", "Domain to data response")]
    public void DomainToDataDtoResponse_ReturnCustomerDataResponse()
    {
        var telephones = TelephoneBuilderTest.NewObject()
                                             .WithETelephoneType(ETelephoneType.CellPhone)
                                             .WithDdi("55")
                                             .WithDdd("18")
                                             .WithPhoneNumber("910889563")
                                             .DomainObject();

        var email = EmailAddressBuilderTest.NewObject()
                                           .WithEmailType(EEmailType.Main)
                                           .WithEmail("email@test.com")
                                           .DomainObject();

        var customer = CustomerBuilderTest.NewObject()
                                          .WithFullName("Client test")
                                          .WithEmails(email)
                                          .WithTelephones(telephones)
                                          .DomainObject();

        var mappingResult = _customerMapper.DomainToDataDtoResponse(customer);

        Assert.NotNull(mappingResult);
        Assert.Equal(email.Email, mappingResult.Email);
        Assert.Equal("+55 (18) 91088-9563", mappingResult.PhoneNumber);
    }


    [Fact]
    [Trait("Mapping", "Domain to data list response")]
    public void DomainToDataDtoResponse_ReturnCustomerDataResponseList()
    {
        var telephones = TelephoneBuilderTest.NewObject()
                                             .WithETelephoneType(ETelephoneType.CellPhone)
                                             .WithDdi("55")
                                             .WithDdd("18")
                                             .WithPhoneNumber("910889563")
                                             .DomainObject();

        var email = EmailAddressBuilderTest.NewObject()
                                           .WithEmailType(EEmailType.Main)
                                           .WithEmail("email@test.com")
                                           .DomainObject();

        List<CustomerBase.API.Business.Domain.Entities.Customer> customers = new()
        {
            {
                CustomerBuilderTest.NewObject()
                                   .WithFullName("Client test")
                                   .WithEmails(email)
                                   .WithTelephones(telephones)
                                   .DomainObject()
            }
        };

        var mappingResult = _customerMapper.DomainToDataDtoResponse(customers);

        Assert.NotEmpty(mappingResult);
        Assert.True(mappingResult.Count == customers.Count);
    }
}
